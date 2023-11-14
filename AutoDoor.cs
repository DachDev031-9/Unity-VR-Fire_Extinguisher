using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AutoDoor : MonoBehaviour{
    public Animator doorAnim;
    public GameObject scanner;
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            doorAnim.SetTrigger("Open");
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            doorAnim.SetTrigger("Close");
        }
    }
}
