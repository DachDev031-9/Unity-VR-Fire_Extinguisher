using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InstructionManualManager : MonoBehaviour{
    public GameObject Area, InstructionManual_1, BookInteraction;
    public bool CheckArea = false;
    public static bool OpenTutorialsStatus, ObjectStatus;
    // Start is called before the first frame update
    void Start(){
        OpenTutorialsStatus = false;
        ObjectStatus = true;
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            Debug.Log("เข้าพื้นที่");
            Area.SetActive(true);
            CheckArea = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            Debug.Log("ออกพื้นที่");
            Area.SetActive(false);
            CheckArea = false;
        }
    }
    public void PauseButtonPressed(InputAction.CallbackContext context){
        if (context.performed){
            ShowBar();
        }
    }
    public void ShowBar(){
        if (ObjectStatus && CheckArea && OpenTutorialsStatus == false){
            InstructionManual_1.SetActive(true);
            BookInteraction.SetActive(false);
            Debug.Log("เปิด");
            ObjectStatus = false;
            OpenTutorialsStatus = true;
            //Time.timeScale = 1;
        }
        /*else if (!ObjectStatus && CheckArea){
            InstructionManual_1.SetActive(false);
            BookInteraction.SetActive(true);
            Debug.Log("ปิด");
            ObjectStatus = true;
            //Time.timeScale = 0;
        }*/
    }
}
