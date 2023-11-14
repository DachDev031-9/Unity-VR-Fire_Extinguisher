using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ColliderIsTrigger : MonoBehaviour{
    Collider m_ObjectCollider;
    public InputActionProperty gripAnimationAction;
    float gripValue;
    bool gripStatus;
    void Start(){
        m_ObjectCollider = GetComponent<Collider>();
        gripStatus = false;
        //Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);
    }
    private void Update(){
        //gripValue = gripAnimationAction.action.ReadValue<float>(); 
        //Debug.Log(gripValue);
        if (gripStatus == true){
            gripValue = 1;
        }else{
            gripValue = 0;
        }
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("RightHand")){
            gripStatus = true;
            if (gripValue == 1){
                m_ObjectCollider.isTrigger = true;
            }
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag.Equals("RightHand")){
            m_ObjectCollider.isTrigger = false;
            gripStatus = false;
        }
    }
}
