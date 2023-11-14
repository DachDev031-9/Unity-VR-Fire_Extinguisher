using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObjectToPlayer : MonoBehaviour{
    public Transform _MainCamera;
    void Update(){
        Vector3 lookAtPosition = transform.position - _MainCamera.position;
        transform.rotation = Quaternion.LookRotation(lookAtPosition);
    }
}
