using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchGreyPZ : MonoBehaviour{
    private AudioSource audioSource;
    public AudioClip LatchSound;
    public static bool LatchStatus_GreyPZ;

    // Start is called before the first frame update
    void Start(){
        audioSource = GetComponent<AudioSource>();
        LatchStatus_GreyPZ = false;
    }
    public void Select(){
        Rigidbody rigid = GetComponent<Rigidbody>();
        if (LatchStatus_GreyPZ == false){
            audioSource.PlayOneShot(LatchSound);
            LatchStatus_GreyPZ = true;
        }
        rigid.constraints &= ~RigidbodyConstraints.FreezePosition;
        rigid.constraints &= ~RigidbodyConstraints.FreezeRotation;
    }
}
