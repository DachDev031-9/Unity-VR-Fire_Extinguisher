using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWM : MonoBehaviour{
    public static bool Area_Fire;
    public AudioClip FireSound;
    private AudioSource audioSource;
    bool SoundStatus;
    void Start(){
        Area_Fire = false;
        audioSource = GetComponent<AudioSource>();
        SoundStatus = true;
    }
    private void LateUpdate(){
        if (Area_Fire == true){
            if (SoundStatus == true){
                SoundEffect();
            }
        }else{
            audioSource.Stop();
            SoundStatus = true;
        }
        audioSource.volume = 1 - (PositionDistance.DistanceSound * 0.01f);
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            Area_Fire = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            Area_Fire = false;
        }
    }
    public void SoundEffect(){
        audioSource.PlayOneShot(FireSound);
        SoundStatus = false;

    }
}
