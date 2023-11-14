using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchRedRZ : MonoBehaviour{
    private AudioSource audioSource;
    public AudioClip LatchSound;
    public static bool LatchStatus_RedRZ;

    // Start is called before the first frame update
    void Start(){
        audioSource = GetComponent<AudioSource>();
        LatchStatus_RedRZ = false;
    }
    public void Select(){
        Rigidbody rigid = GetComponent<Rigidbody>();
        if (LatchStatus_RedRZ == false){
            audioSource.PlayOneShot(LatchSound);
            LatchStatus_RedRZ = true;
        }
        rigid.constraints &= ~RigidbodyConstraints.FreezePosition;
        rigid.constraints &= ~RigidbodyConstraints.FreezeRotation;
    }
}
