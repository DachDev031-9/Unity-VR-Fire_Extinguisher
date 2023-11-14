using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectWM : MonoBehaviour{
    public GameObject HideObject;
    // Start is called before the first frame update
    void Start(){
        HideObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            HideObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            HideObject.SetActive(false);
        }
    }
}
