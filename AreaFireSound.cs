using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaFireSound : MonoBehaviour
{
    bool Area_Fire;
    public AudioClip FireSound;
    private AudioSource audioSource;
    bool SoundStatus;
    // Start is called before the first frame update
    void Start()
    {
        Area_Fire = false;
        audioSource = GetComponent<AudioSource>();
        SoundStatus = true;
    }

    // Update is called once per frame
    private void LateUpdate(){
        if (Area_Fire == true && (TimeSimuration.GreenZone == false || TimeSimuration.RedZone == false || TimeSimuration.YellowZone == false || TimeSimuration.GreyZone == false)){
            if (SoundStatus == true){
                SoundEffect();
            }
        }
        else
        {
            audioSource.Stop();
            SoundStatus = true;
        }
        audioSource.volume = 1 - (PositionDistance.DistanceSound * 0.01f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Area_Fire = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Area_Fire = false;
        }
    }
    public void SoundEffect()
    {
        audioSource.PlayOneShot(FireSound);
        SoundStatus = false;

    }
}
