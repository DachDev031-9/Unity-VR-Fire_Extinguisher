using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RandomPlayer : MonoBehaviour{
    public GameObject Player, Summarize, Timebar;
    public GameObject[] Event;
    public static bool[] Fire = new bool[48];
    public static bool FireExtinguisherSuccess; // เช็คสถานะการดับเพลิง เพื่อทำการสุ่มจุดใหม่
    int RandomPlayerPoint, RandomFirePoint, CountFire, remainingDuration, countMax, Remainingtime;
    public static bool GameOverStatus;
    public Text Name, Time, MaxFire, FirePoint, Rank;
    [SerializeField] private Text uiText, TimeText;
    public static string namePlayer;
    bool gameFinishCheck, FireExtinguisherDefault;
    // Start is called before the first frame update
    void Start(){
        Fire[0] = true;
        Fire[1] = true;
        Fire[2] = true;
        Fire[3] = true;
        Fire[4] = true;
        Fire[5] = true;
        Fire[6] = true;
        Fire[7] = true;
        Fire[8] = true;
        Fire[9] = true;
        Fire[10] = true;
        Fire[11] = true;

        Fire[12] = true;
        Fire[13] = true;
        Fire[14] = true;
        Fire[15] = true;
        Fire[16] = true;
        Fire[17] = true;
        Fire[18] = true;
        Fire[19] = true;
        Fire[20] = true;
        Fire[21] = true;
        Fire[22] = true;
        Fire[23] = true;

        Fire[24] = true;
        Fire[25] = true;
        Fire[26] = true;
        Fire[27] = true;
        Fire[28] = true;
        Fire[29] = true;
        Fire[30] = true;
        Fire[31] = true;
        Fire[32] = true;
        Fire[33] = true;
        Fire[34] = true;
        Fire[35] = true;

        Fire[36] = true;
        Fire[37] = true;
        Fire[38] = true;
        Fire[39] = true;
        Fire[40] = true;
        Fire[41] = true;
        Fire[42] = true;
        Fire[43] = true;
        Fire[44] = true;
        Fire[45] = true;
        Fire[46] = true;
        Fire[47] = true;

        if (SettingGame.RedPoint == 1 && SettingGame.GreenPoint == 1 && SettingGame.YellowPoint == 1 && SettingGame.GreyPoint == 1){
            FireExtinguisherDefault = true;
        }
        gameFinishCheck = true;
        GameOverStatus = false;
        Summarize.SetActive(false);
        CountFire = SettingGame.RedPoint + SettingGame.GreenPoint + SettingGame.YellowPoint + SettingGame.GreyPoint;
        countMax = CountFire;
        RandomPlayerPoint = Random.Range(0, 12);
        RandomFirePoint = Random.Range(0, 48);
        Debug.Log("Player " + RandomPlayerPoint);
        Debug.Log("Fire " + RandomFirePoint);
        FireExtinguisherSuccess = true;
        RandomSpawnPlayer();
        Being(TimeSimuration.Time);
        if (SettingGame.GameMode == true){
            Timebar.SetActive(true);
        }else{
            Timebar.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update(){
        if (CountFire > 0 && FireExtinguisherSuccess == true){
            if (Fire[RandomFirePoint] == true){
                if (RandomFirePoint >= 0 && RandomFirePoint <= 11 && SettingGame.RedPoint > 0) {
                    Event[RandomFirePoint].SetActive(true);
                    FireExtinguisherSuccess = false;
                    CountFire -= 1;
                    SettingGame.RedPoint -= 1;
                    Debug.Log("จำนวนที่เหลือ" + CountFire);
                    Debug.Log(SettingGame.RedPoint);
                } else if (RandomFirePoint >= 12 && RandomFirePoint <= 23 && SettingGame.GreenPoint > 0) {
                    Event[RandomFirePoint].SetActive(true);
                    FireExtinguisherSuccess = false;
                    CountFire -= 1;
                    Debug.Log(SettingGame.GreenPoint);
                    SettingGame.GreenPoint -= 1;
                    Debug.Log("จำนวนที่เหลือ" + CountFire);
                    Debug.Log(SettingGame.GreenPoint);
                }
                else if (RandomFirePoint >= 24 && RandomFirePoint <= 35 && SettingGame.YellowPoint > 0) {
                    Event[RandomFirePoint].SetActive(true);
                    FireExtinguisherSuccess = false;
                    CountFire -= 1;
                    SettingGame.YellowPoint -= 1;
                    Debug.Log("จำนวนที่เหลือ" + CountFire);
                    Debug.Log(SettingGame.YellowPoint);
                }
                else if (RandomFirePoint >= 36 && RandomFirePoint <= 47 && SettingGame.GreyPoint > 0){
                    Event[RandomFirePoint].SetActive(true);
                    FireExtinguisherSuccess = false;
                    CountFire -= 1;
                    SettingGame.GreyPoint -= 1;
                    Debug.Log("จำนวนที่เหลือ" + CountFire);
                    Debug.Log(SettingGame.GreyPoint);
                }else{
                    RandomFirePoint = Random.Range(0, 48);
                }
            }else{
                RandomFirePoint = Random.Range(0, 48);
            }
        }
        if (SettingGame.GameMode == true && FireExtinguisherDefault == true){
            if ((CountFire == 0 && FireExtinguisherSuccess == true) || remainingDuration == 0 && gameFinishCheck == true){
                GameOver();
                gameFinishCheck = false;
            }
        }else{
            if (CountFire == 0 && FireExtinguisherSuccess == true && gameFinishCheck == true){
                GameOver();
                gameFinishCheck = false;
            }
        }
    }
    private void RandomSpawnPlayer(){
        if (RandomPlayerPoint == 0){
            Player.transform.position = new Vector3(70, 0, 60);
        }else if (RandomPlayerPoint == 1){
            Player.transform.position = new Vector3(45, 0, 79);
        }else if (RandomPlayerPoint == 2){
            Player.transform.position = new Vector3(73, 0, 93);
        }else if (RandomPlayerPoint == 3){
            Player.transform.position = new Vector3(41, 0, 81);
        }else if (RandomPlayerPoint == 4){
            Player.transform.position = new Vector3(21, 0, 80);
        }else if (RandomPlayerPoint == 5){
            Player.transform.position = new Vector3(29, 0, 58);
        }else if (RandomPlayerPoint == 6){
            Player.transform.position = new Vector3(21, 0, 54);
        }else if (RandomPlayerPoint == 7){
            Player.transform.position = new Vector3(12, 0, 2);
        }else if (RandomPlayerPoint == 8){
            Player.transform.position = new Vector3(42, 0, 17);
        }else if (RandomPlayerPoint == 9){
            Player.transform.position = new Vector3(48, 0, 48);
        }else if (RandomPlayerPoint == 10){
            Player.transform.position = new Vector3(66, 0, 24);
        }else if (RandomPlayerPoint == 11){
            Player.transform.position = new Vector3(55, 3, 34);
        }
    }
    public void GameOver(){
        Summarize.SetActive(true);
        Remainingtime = TimeSimuration.Time - remainingDuration;
        Name.text = $"ชื่อผู้เล่น : {DatabaseManager.usernameField}";
        if (Remainingtime <= 120){
            Rank.text = $"S";
        }else if (Remainingtime > 120 && Remainingtime <= 240){
            Rank.text = $"A";
        }else if (Remainingtime > 240 && Remainingtime <= 360){
            Rank.text = $"B";
        }else if (Remainingtime > 360 && Remainingtime <= 480){
            Rank.text = $"C";
        }else if (Remainingtime > 480 && Remainingtime <= 600){
            Rank.text = $"D";
        }
        if (SettingGame.GameMode == true && FireExtinguisherDefault == true){
            Time.text = $"{Remainingtime / 60:00} : {Remainingtime % 60:00}";
            DatabaseManager.TimeScore = Time.text;
            DatabaseManager.FireExtinguisherFinish = $"{countMax - CountFire}";
            DatabaseManager.grade = Rank.text;
        }
        else{
            Time.text = $"ใช้เวลา 00:00 นาที";
        }
        MaxFire.text = $"จำนวนจุดเกิดเพลิงไหม้ : {countMax} จุด";
        FirePoint.text = $"เหลือ : {CountFire} จุด";
        GameOverStatus = true; // ตื่นมาเช็คต่อ เพราะมันวนลูปตลอดเวลา
    }
    private void Being(int Second){
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer(){
        while (remainingDuration >= 0){
            uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
            if (GameOverStatus == false){
                remainingDuration--;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    public void LoadScene(){
        SceneManager.LoadScene("MainMenu");
    }
}
