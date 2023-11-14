using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour{
    public GameObject ObjectInput;
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            ObjectInput.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            ObjectInput.SetActive(false);
        }
    }
}
