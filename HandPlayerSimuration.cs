using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HandPlayerSimuration : MonoBehaviour{
    public GameObject MenuButton, DataFireExtinguisherButton, JoyControllerButton;
    public void LoadSceneMainMenu(){
        SceneManager.LoadScene("MainMenu");
        //DatabaseManager.MainManuButton = true;
        //RandomPlayer.GameOverStatus = true;
    }
    public void Menu(){
        MenuButton.SetActive(true);
        DataFireExtinguisherButton.SetActive(false);
        JoyControllerButton.SetActive(false);
    }
    public void DataFireExtinguisher(){
        DataFireExtinguisherButton.SetActive(true);
        MenuButton.SetActive(false);
        JoyControllerButton.SetActive(false);
    }
    public void JoyController(){
        JoyControllerButton.SetActive(true);
        MenuButton.SetActive(false);
        DataFireExtinguisherButton.SetActive(false);
    }
}
