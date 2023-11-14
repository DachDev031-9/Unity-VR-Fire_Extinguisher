using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.SceneManagement;

public class GetValueManager : MonoBehaviour{
    public GameObject wristUI, DataFireExtinguisher, JoyController;
    public bool activewristUI = true;
    // Start is called before the first frame update
    void Start(){
        DisplayWristUI();
    }
    /*public void ExitGame(){
        Application.Quit();
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/
    public void PauseButtonPressed(InputAction.CallbackContext context){
        if (context.performed){
            DisplayWristUI();
        }
    }
    public void DisplayWristUI(){
        if (activewristUI){
            wristUI.SetActive(false);
            activewristUI = false;
            //Time.timeScale = 1;
        }else if (!activewristUI){
            wristUI.SetActive(true);
            activewristUI = true;
            DataFireExtinguisher.SetActive(false);
            JoyController.SetActive(false);
            //Time.timeScale = 0;
        }
    }
}
