using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchRed : MonoBehaviour{
    private AudioSource audioSource;
    public AudioClip LatchSound;
    public static bool LatchStatus_Red;

    // Start is called before the first frame update
    void Start(){
        audioSource = GetComponent<AudioSource>();
        LatchStatus_Red = false;
    }
    public void Select(){
        Rigidbody rigid = GetComponent<Rigidbody>();
        if (LatchStatus_Red == false){
            audioSource.PlayOneShot(LatchSound);
            LatchStatus_Red = true;
        }
        rigid.constraints &= ~RigidbodyConstraints.FreezePosition;
        rigid.constraints &= ~RigidbodyConstraints.FreezeRotation;
    }
}
