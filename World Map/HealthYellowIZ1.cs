using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthYellowIZ1 : MonoBehaviour{
    public float Health_target;
    bool BulletBodyStatus; // ตัวแปรเช็คว่า Object ชนกับ สารดับเพลิงแล้วหรือยัง
    public GameObject fire, FireZone;
    bool Success;
    [SerializeField] private Slider slider_health = null;
    [SerializeField] private Text HPPercent = null;
    void Start(){
        BulletBodyStatus = false;
        Success = false;
    }
    void Update(){
        if (BulletBodyStatus == true && (BulletYellowRZ.CheckBullet == true || BulletYellowPZ.CheckBullet == true || BulletYellowIZ.CheckBullet == true || BulletYellowHZ.CheckBullet == true)){
            slider_health.value -= Health_target;
        }else{
            slider_health.value += 0;
        }
        fire.transform.localScale = new Vector3(0.001f * slider_health.value, 0.001f * slider_health.value, 0.001f * slider_health.value);
        if (slider_health.value <= 0){
            slider_health.value = 0;
            FireZone.SetActive(false);
            if (Success == false){
                RandomPlayer.Fire[24] = false;
                AreaWM.Area_Fire = false;
                RandomPlayer.FireExtinguisherSuccess = true;
                Success = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Bullet_Yellow")){
            BulletBodyStatus = true;
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag.Equals("Bullet_Yellow")){
            BulletBodyStatus = false;
        }
    }
    public void VolumeSlider(float volume){
        HPPercent.text = volume.ToString();
    }
}
