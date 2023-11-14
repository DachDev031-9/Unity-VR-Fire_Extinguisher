using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstructionManual : MonoBehaviour{
    public GameObject InstructionManual_Before, InstructionManual_This, InstructionManual_Next;
    public Button Button_Next, Button_Back;
    void Update(){
        Button_Next.onClick.AddListener(delegate(){
            InstructionManual_Next.SetActive(true);
            InstructionManual_This.SetActive(false);
        });
        Button_Back.onClick.AddListener(delegate(){
            InstructionManual_Before.SetActive(true);
            InstructionManual_This.SetActive(false);
        });
    }
}
