using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonKeyboard : MonoBehaviour{
    public InputField emailLoginField, passwordLoginField;
    public InputField nameregisterField, emailregisterField, passwordregisterField, confirmpaswwordregisterField;
    public GameObject EngCap, EngLit, THCap, THLit;
    public GameObject EngCap_Register, EngLit_Register, THCap_Register, THLit_Register;
    public static int CheckInputField;
    void Start(){
        CheckInputField = 1;
    }
    public void Typing(string a){
        if (CheckInputField == 1){
            emailLoginField.text += a;
        }else if(CheckInputField == 2){
            passwordLoginField.text += a;
        }else if (CheckInputField == 3){
            nameregisterField.text += a;
        }else if (CheckInputField == 4){
            emailregisterField.text += a;
        }else if (CheckInputField == 5){
            passwordregisterField.text += a;
        }else if (CheckInputField == 6){
            confirmpaswwordregisterField.text += a;
        }
    }
    public void Space(){
        if (CheckInputField == 1){
            emailLoginField.text += " ";
        }else if(CheckInputField == 2){
            passwordLoginField.text += " ";
        }else if (CheckInputField == 3){
            nameregisterField.text += " ";
        }else if (CheckInputField == 4){
            emailregisterField.text += " ";
        }else if (CheckInputField == 5){
            passwordregisterField.text += " ";
        }else if (CheckInputField == 6){
            confirmpaswwordregisterField.text += " ";
        }
    }
    public void Delete(){
        if (CheckInputField == 1){
            if (emailLoginField.text.Length > 0){
                emailLoginField.text = emailLoginField.text.Substring(0, emailLoginField.text.Length - 1); // เริ่มตั้งแต่ 0 ถึง (ตัวสุดท้าย -1)
            }
        }else if(CheckInputField == 2){
            if (passwordLoginField.text.Length > 0){
                passwordLoginField.text = passwordLoginField.text.Substring(0, passwordLoginField.text.Length - 1); // เริ่มตั้งแต่ 0 ถึง (ตัวสุดท้าย -1)
            }
        }else if (CheckInputField == 3){
            if (nameregisterField.text.Length > 0){
                nameregisterField.text = nameregisterField.text.Substring(0, nameregisterField.text.Length - 1); // เริ่มตั้งแต่ 0 ถึง (ตัวสุดท้าย -1)
            }
        }else if (CheckInputField == 4){
            if (emailregisterField.text.Length > 0){
                emailregisterField.text = emailregisterField.text.Substring(0, emailregisterField.text.Length - 1); // เริ่มตั้งแต่ 0 ถึง (ตัวสุดท้าย -1)
            }
        }else if (CheckInputField == 5){
            if (passwordregisterField.text.Length > 0){
                passwordregisterField.text = passwordregisterField.text.Substring(0, passwordregisterField.text.Length - 1); // เริ่มตั้งแต่ 0 ถึง (ตัวสุดท้าย -1)
            }
        }else if (CheckInputField == 6){
            if (confirmpaswwordregisterField.text.Length > 0){
                confirmpaswwordregisterField.text = confirmpaswwordregisterField.text.Substring(0, confirmpaswwordregisterField.text.Length - 1); // เริ่มตั้งแต่ 0 ถึง (ตัวสุดท้าย -1)
            }
        }
    }
    public void CapitalEng(){
        EngCap.SetActive(true);
        EngLit.SetActive(false);
        THCap.SetActive(false);
        THLit.SetActive(false);

        EngCap_Register.SetActive(true);
        EngLit_Register.SetActive(false);
        THCap_Register.SetActive(false);
        THLit_Register.SetActive(false);
    }
    public void LittleEng(){
        EngLit.SetActive(true);
        EngCap.SetActive(false);
        THCap.SetActive(false);
        THLit.SetActive(false);

        EngLit_Register.SetActive(true);
        EngCap_Register.SetActive(false);
        THCap_Register.SetActive(false);
        THLit_Register.SetActive(false);
    }
    public void CapitalThai(){
        EngLit.SetActive(false);
        EngCap.SetActive(false);
        THCap.SetActive(true);
        THLit.SetActive(false);

        EngLit_Register.SetActive(false);
        EngCap_Register.SetActive(false);
        THCap_Register.SetActive(true);
        THLit_Register.SetActive(false);
    }
    public void LittleThai(){
        EngLit.SetActive(false);
        EngCap.SetActive(false);
        THCap.SetActive(false);
        THLit.SetActive(true);

        EngLit_Register.SetActive(false);
        EngCap_Register.SetActive(false);
        THCap_Register.SetActive(false);
        THLit_Register.SetActive(true);
    }
    public void English(){
        EngLit.SetActive(true);
        EngCap.SetActive(false);
        THCap.SetActive(false);
        THLit.SetActive(false);

        EngLit_Register.SetActive(true);
        EngCap_Register.SetActive(false);
        THCap_Register.SetActive(false);
        THLit_Register.SetActive(false);
    }
    public void Thai(){
        EngLit.SetActive(false);
        EngCap.SetActive(false);
        THCap.SetActive(false);
        THLit.SetActive(true);

        EngLit_Register.SetActive(false);
        EngCap_Register.SetActive(false);
        THCap_Register.SetActive(false);
        THLit_Register.SetActive(true);
    }
    public void CheckInputEmailFieldLogin(){
        CheckInputField = 1;
    }
    public void CheckInputPasswordFieldLogin(){
        CheckInputField = 2;
    }
    public void CheckInputNameFieldRegister(){
        CheckInputField = 3;
    }
    public void CheckInputEmailFieldRegister(){
        CheckInputField = 4;
    }
    public void CheckInputPasswordFieldRegister(){
        CheckInputField = 5;
    }
    public void CheckInputConfirmpasswordFieldRegister(){
        CheckInputField = 6;
    }
}
