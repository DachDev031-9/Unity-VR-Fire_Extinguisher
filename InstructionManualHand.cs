using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstructionManualHand : MonoBehaviour{
    public GameObject InstructionManual_Before, InstructionManual_This;
    public Button Button_Back;
    void Update(){
        Button_Back.onClick.AddListener(delegate () {
            InstructionManual_Before.SetActive(true);
            InstructionManual_This.SetActive(false);
        });
    }
}
