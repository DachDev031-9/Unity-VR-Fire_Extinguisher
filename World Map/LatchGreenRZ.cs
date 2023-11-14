using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchGreenRZ : MonoBehaviour{
    private AudioSource audioSource;
    public AudioClip LatchSound;
    public static bool LatchStatus_GreenRZ;

    // Start is called before the first frame update
    void Start(){
        audioSource = GetComponent<AudioSource>();
        LatchStatus_GreenRZ = false;
    }
    public void Select(){
        Rigidbody rigid = GetComponent<Rigidbody>();
        if (LatchStatus_GreenRZ == false){
            audioSource.PlayOneShot(LatchSound);
            LatchStatus_GreenRZ = true;
        }
        rigid.constraints &= ~RigidbodyConstraints.FreezePosition;
        rigid.constraints &= ~RigidbodyConstraints.FreezeRotation;
    }
}
