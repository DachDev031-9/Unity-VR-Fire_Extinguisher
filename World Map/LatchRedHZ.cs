using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatchRedHZ : MonoBehaviour{
    private AudioSource audioSource;
    public AudioClip LatchSound;
    public static bool LatchStatus_RedHZ;

    // Start is called before the first frame update
    void Start(){
        audioSource = GetComponent<AudioSource>();
        LatchStatus_RedHZ = false;
    }
    public void Select(){
        Rigidbody rigid = GetComponent<Rigidbody>();
        if (LatchStatus_RedHZ == false){
            audioSource.PlayOneShot(LatchSound);
            LatchStatus_RedHZ = true;
        }
        rigid.constraints &= ~RigidbodyConstraints.FreezePosition;
        rigid.constraints &= ~RigidbodyConstraints.FreezeRotation;
    }
}
