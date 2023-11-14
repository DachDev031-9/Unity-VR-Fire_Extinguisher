using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchGreyRZ : MonoBehaviour{
    private AudioSource audioSource;
    public AudioClip LatchSound;
    public static bool LatchStatus_GreyRZ;

    // Start is called before the first frame update
    void Start(){
        audioSource = GetComponent<AudioSource>();
        LatchStatus_GreyRZ = false;
    }
    public void Select(){
        Rigidbody rigid = GetComponent<Rigidbody>();
        if (LatchStatus_GreyRZ == false){
            audioSource.PlayOneShot(LatchSound);
            LatchStatus_GreyRZ = true;
        }
        rigid.constraints &= ~RigidbodyConstraints.FreezePosition;
        rigid.constraints &= ~RigidbodyConstraints.FreezeRotation;
    }
}
