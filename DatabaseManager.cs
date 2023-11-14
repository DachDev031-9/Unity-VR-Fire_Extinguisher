using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using UnityEngine.UI;
using System.Linq;

public class DatabaseManager : MonoBehaviour{
    public static bool onlineStatus;
    bool SaveDataCheck;
    public static bool MainManuButton;

    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBreference;

    //Login variables
    [Header("Login")]
    public InputField emailLoginField;
    public InputField passwordLoginField;
    public Text warningLoginText;
    public Text confirmLoginText;

    //Register variables
    [Header("Register")]
    public InputField usernameRegisterField;
    public InputField emailRegisterField;
    public InputField passwordRegisterField;
    public InputField passwordRegisterVerifyField;
    public Text warningRegisterText;

    //User Data variables
    [Header("UserData")]
    /*public InputField usernameField;
    public InputField xpField;
    public InputField killsField;
    public InputField deathsField;*/
    public static string email,password;

    public static string usernameField;
    public static string xpField;
    public static string TimeScore;
    public static string deathsField;
    public static string FireExtinguisherFinish;
    public static string grade;
    public GameObject scoreElement;
    public Transform scoreboardContent;

    private void Start(){
        onlineStatus = false;
        SaveDataCheck = true;
    }
    void Awake(){
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>{
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available){
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }else{
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }
    private void Update(){
        /*if (MainManuButton == true){
            LoginButton();
            ScoreboardButton();
            MainManuButton = false;
        }*/
        if (RandomPlayer.GameOverStatus == true)
        {
            LoginButton();
            SaveDataCheck = false;
            RandomPlayer.GameOverStatus = false;
        }
            //Debug.Log("ÅçÍ¤ÍÔ¹áÅéÇ");
            //Debug.Log(onlineStatus);
        if (onlineStatus == true && SaveDataCheck == false){
                SaveDataButton();
                Debug.Log("ºÑ¹·Ö¡áÅéÇ");
                SaveDataCheck = true;
                ScoreboardButton();
                //RandomPlayer.GameOverStatus = false;
        }   
    }
    private void InitializeFirebase(){
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    public void ClearLoginFeilds(){
        emailLoginField.text = "";
        passwordLoginField.text = "";
    }
    public void ClearRegisterFeilds(){
        usernameRegisterField.text = "";
        emailRegisterField.text = "";
        passwordRegisterField.text = "";
        passwordRegisterVerifyField.text = "";
    }
    public void LoginButton() {
        //Call the login coroutine passing the email and password
        if (RandomPlayer.GameOverStatus == true) {
            StartCoroutine(Login(email, password));
        }else{
            StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
            ScoreboardButton();
        }   
    }
    public void RegisterButton(){
        //Call the register coroutine passing the email, password, and username
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text));
    }
    public void SignOutButton(){
        auth.SignOut();
        //UIManager.instance.LoginScreen();
        UserInterfaceManager.instance.LoginScreen();
        ClearRegisterFeilds();
        ClearLoginFeilds();
        onlineStatus = false;
    }
    public void SaveDataButton(){
        StartCoroutine(UpdateUsernameAuth(usernameField));
        StartCoroutine(UpdateUsernameDatabase(usernameField));
        StartCoroutine(UpdateXp(grade));
        StartCoroutine(UpdateKills(TimeScore));
        StartCoroutine(UpdateDeaths(FireExtinguisherFinish));
        RandomPlayer.GameOverStatus = false;
    }
    //Function for the scoreboard button
    public void ScoreboardButton(){
        StartCoroutine(LoadScoreboardData());
    }
    private IEnumerator Login(string _email, string _password){
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null){
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.text = message;
        }else{
            //User is now logged in
            //Now get the result
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            confirmLoginText.text = "Logged In";
            StartCoroutine(LoadUserData());

            //yield return new WaitForSeconds(2);

            usernameField = User.DisplayName;
            
            email = emailLoginField.text;
            password = passwordLoginField.text;

            //xpField = "-";
            //TimeScore = "-";
            //deathsField = "-";

            //UIManager.instance.UserDataScreen(); // Change to user data UI
            UserInterfaceManager.instance.UserDataScreen(); // Change to user data UI
            confirmLoginText.text = "";
            ClearLoginFeilds();
            ClearRegisterFeilds();

            onlineStatus = true;
            Debug.Log("ÍÍ¹äÅ¹ìáÅéÇ");
        }
    }
    private IEnumerator Register(string _email, string _password, string _username){
        if (_username == "")
        {
            //If the username field is blank show a warning
            warningRegisterText.text = "Missing Username";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            //If the password does not match show a warning
            warningRegisterText.text = "Password Does Not Match!";
        }
        else
        {
            //Call the Firebase auth signin function passing the email and password
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegisterText.text = message;
            }
            else
            {
                //User has now been created
                //Now get the result
                User = RegisterTask.Result;

                if (User != null)
                {
                    //Create a user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    //Call the Firebase auth update user profile function passing the profile with the username
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        //If there are errors handle them
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {
                        //Username is now set
                        //Now return to login screen
                        UserInterfaceManager.instance.LoginScreen();
                        //UIManager.instance.LoginScreen();
                        warningRegisterText.text = "";
                        ClearRegisterFeilds();
                        ClearLoginFeilds();
                    }
                }
            }
        }
    }
    private IEnumerator UpdateUsernameAuth(string _username){
        //Create a user profile and set the username
        UserProfile profile = new UserProfile { DisplayName = _username };

        //Call the Firebase auth update user profile function passing the profile with the username
        var ProfileTask = User.UpdateUserProfileAsync(profile);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

        if (ProfileTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
        }
        else
        {
            //Auth username is now updated
        }
    }

    private IEnumerator UpdateUsernameDatabase(string _username)
    {
        //Set the currently logged in user username in the database
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("username").SetValueAsync(_username);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database username is now updated
        }
    }
    private IEnumerator UpdateXp(string _xp)
    {
        //Set the currently logged in user xp
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("Rank").SetValueAsync(_xp);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Xp is now updated
        }
    }

    private IEnumerator UpdateKills(string _kills)
    {
        //Set the currently logged in user kills
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("TimeScore").SetValueAsync(_kills);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Kills are now updated
        }
    }

    private IEnumerator UpdateDeaths(string _deaths)
    {
        //Set the currently logged in user deaths
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("FirePoint").SetValueAsync(_deaths);
        //var DBTask = DBreference.Child("users").Child(User.UserId).Child("FirePoint").SetValueAsync(_deaths);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Deaths are now updated
        }
    }
    private IEnumerator LoadUserData()
    {
        //Get the currently logged in user data
        var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists yet
            /*xpField.text = "0";
            killsField.text = "0";
            deathsField.text = "0";*/

            //xpField = "-";
            TimeScore = "00 : 00";
            //deathsField = "-";
            grade = "D";
            FireExtinguisherFinish = "0";
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            /*pField.text = snapshot.Child("xp").Value.ToString();
            killsField.text = snapshot.Child("kills").Value.ToString();
            deathsField.text = snapshot.Child("deaths").Value.ToString();*/

            //xpField = snapshot.Child("xp").Value.ToString();
            grade = snapshot.Child("Rank").Value.ToString();
            TimeScore = snapshot.Child("TimeScore").Value.ToString();
            //deathsField = snapshot.Child("deaths").Value.ToString();
            FireExtinguisherFinish = snapshot.Child("FirePoint").Value.ToString();
        }
    }
    private IEnumerator LoadScoreboardData()
    {
        //Get all the users data ordered by kills amount
        var DBTask = DBreference.Child("users").OrderByChild("TimeScore").GetValueAsync();
        //firebase.database().ref('users').orderByValue().on('value',function(snapshot){
        // snapshot.forEach(function(childSnapshot){
        // var userScore = childSnapshot.val();
        // console.log("User score:" + userScore);
        //});

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            //Destroy any existing scoreboard elements
            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            //Loop through every users UID
            foreach (DataSnapshot childSnapshot in snapshot.Children)
            //foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
                {
                string username = childSnapshot.Child("username").Value.ToString();
                string TimeScore = childSnapshot.Child("TimeScore").Value.ToString();
                string FireExtinguisherFinish = childSnapshot.Child("FirePoint").Value.ToString();
                //int deaths = int.Parse(childSnapshot.Child("deaths").Value.ToString());
                //int xp = int.Parse(childSnapshot.Child("xp").Value.ToString());
                string Grade = childSnapshot.Child("Rank").Value.ToString();

                //Instantiate new scoreboard elements
                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(username, TimeScore, FireExtinguisherFinish, Grade);
                
            }

            //Go to scoareboard screen
            UserInterfaceManager.instance.ScoreboardScreen();
            //UIManager.instance.ScoreboardScreen();
        }
    }
}
