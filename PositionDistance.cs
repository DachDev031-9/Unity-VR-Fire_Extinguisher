using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionDistance : MonoBehaviour{
    public GameObject player, target;
    public Transform _maincamera;
    public Text distance_player;
    public static int DistanceSound;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        float distance = Vector3.Distance(player.transform.position, target.transform.position);
        int iValue = (int)distance;
        distance_player.text = "ระยะห่าง " + iValue + " เมตร";




        DistanceSound = iValue;
        Vector3 lookAtPosition = transform.position - _maincamera.position;
        transform.rotation = Quaternion.LookRotation(lookAtPosition);
    }
}
