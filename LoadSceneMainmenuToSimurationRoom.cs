using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class LoadSceneMainmenuToSimurationRoom : MonoBehaviour{
    public GameObject PanelCredits, PanelMainmenu, PanelJoyController;
    public void LoadSceneSimurationRoom(){
        SceneManager.LoadScene("Simulation 1");
    }
    public void Credits(){
        PanelCredits.SetActive(true);
        PanelMainmenu.SetActive(false);
    }
    public void Mainmenu(){
        PanelMainmenu.SetActive(true);
        PanelCredits.SetActive(false);
        PanelJoyController.SetActive(false);
    }
    public void JoyController(){
        PanelJoyController.SetActive(true);
        PanelMainmenu.SetActive(false);
    }
    public void ExitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
