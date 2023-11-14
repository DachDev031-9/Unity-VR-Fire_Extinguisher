using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRed : MonoBehaviour{
    public GameObject Bullet_Fire;
    public Transform SpawnPoint;
    public AudioClip FireSound;
    private AudioSource audioSource;
    public static bool CheckBullet; // ตัวแปรเช็ค Ontrigger แก้ปัญหา เวลาออกจากพื้นที่ แต่ HP ยังลดอยู่
    Collider Body;
    bool SelectObjectStatus, ActivateObjectStatus, RightHandStatus, LeftHandStatus, PlaySoundStatus;
    // Start is called before the first frame update
    void Start(){
        audioSource = GetComponent<AudioSource>();
        Body = GetComponent<Collider>();
        SelectObjectStatus = false;
        ActivateObjectStatus = false;
        RightHandStatus = false;
        LeftHandStatus = false;
        Bullet_Fire.SetActive(false);
        PlaySoundStatus = true;
        CheckBullet = false;
    }
    // Update is called once per frame
    void Update(){
        if (RightHandStatus == true && SelectObjectStatus == true && ActivateObjectStatus == true && Area.Area_Fire == true && LatchRed.LatchStatus_Red == true){
            Bullet_Fire.SetActive(true);
            if (PlaySoundStatus == true){
                PlaySound();
                CheckBullet = true;
            }
        }else if (LeftHandStatus == true && SelectObjectStatus == true && ActivateObjectStatus == true && Area.Area_Fire == true && LatchRed.LatchStatus_Red == true){
            Bullet_Fire.SetActive(true);
            if (PlaySoundStatus == true){
                PlaySound();
                CheckBullet = true;
            }
        }else{
            Bullet_Fire.SetActive(false);
            audioSource.Stop();
            PlaySoundStatus = true;
            CheckBullet = false;
        }
    }
    public void SelectObject(){
        SelectObjectStatus = true;
        Body.isTrigger = true;
    }
    public void DeSelectObject(){
        SelectObjectStatus = false;
        Body.isTrigger = false;
    }
    public void ActivateObject(){
        ActivateObjectStatus = true;
    }
    public void DeActivateObject(){
        ActivateObjectStatus = false;
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("RightHand")){
            RightHandStatus = true;
        }
        if (other.gameObject.tag.Equals("LeftHand")){
            LeftHandStatus = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag.Equals("RightHand")){
            RightHandStatus = false;
        }
        if (other.gameObject.tag.Equals("LeftHand")){
            LeftHandStatus = false;
        }
    }
    private void PlaySound(){
        audioSource.PlayOneShot(FireSound);
        PlaySoundStatus = false;
    }
}
