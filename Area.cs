using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour{
    public static bool Area_Fire;
    public GameObject Red, Green;
    void Start(){
        Area_Fire = false;
        Green.SetActive(false);
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            Area_Fire = true;
            Red.SetActive(false);
            Green.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            Area_Fire = false;
            Red.SetActive(true);
            Green.SetActive(false);
        }
    }
}
