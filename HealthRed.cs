using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthRed : MonoBehaviour{
    public float Health_target;
    bool BulletBodyStatus; // ตัวแปรเช็คว่า Object ชนกับ สารดับเพลิงแล้วหรือยัง
    public GameObject fire;
    [SerializeField] private Slider slider_health = null;
    [SerializeField] private Text HPPercent = null;
    void Start(){
        BulletBodyStatus = false;
        fire.SetActive(true);
    }
    void Update(){
        if (BulletBodyStatus == true && BulletRed.CheckBullet == true){
            slider_health.value -= Health_target;
        }else{
            slider_health.value += 0;
        }
        fire.transform.localScale = new Vector3(0.001f * slider_health.value, 0.001f * slider_health.value, 0.001f * slider_health.value);
        if (slider_health.value <= 0){
            slider_health.value = 0;
            fire.SetActive(false);
            TimeSimuration.RedZone = true;
        }
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Bullet_Red")){
            BulletBodyStatus = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag.Equals("Bullet_Red")){
            BulletBodyStatus = false;
        }
    }
    public void VolumeSlider(float volume){
        HPPercent.text = volume.ToString();
    }
}
