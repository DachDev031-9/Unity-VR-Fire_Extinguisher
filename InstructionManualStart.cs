using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstructionManualStart : MonoBehaviour{
    public GameObject InstructionManual_This, InstructionManual_Next;
    public Button Button_Next;
    void Update(){
        Button_Next.onClick.AddListener(delegate () {
            InstructionManual_Next.SetActive(true);
            InstructionManual_This.SetActive(false);
        });
    }
}
