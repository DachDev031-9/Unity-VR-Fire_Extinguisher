using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingGame : MonoBehaviour{
    public static int FirePoint, TimePoint, RedPoint, GreenPoint, YellowPoint, GreyPoint, SecondPoint;
    public Text NumRed, NumGreen, NumGrey, NumYellow, NumSecond, NumFire, NumTime;
    public GameObject Mainmenu, Setting;
    public Toggle Mode;
    public GameObject SettingTime, PointTime;
    public static bool GameMode;
    // Start is called before the first frame update
    void Start(){
        Mode = Mode.GetComponent<Toggle>();
        GameMode = true;

        FirePoint = 8;
        TimePoint = 5;

        RedPoint = 1;
        GreenPoint = 1;
        YellowPoint = 1;
        GreyPoint = 1;
        SecondPoint = 10;
    }
    public void RedPlus(){
        if (FirePoint > 0){
            RedPoint += 1;
            FirePoint -= 1;
            NumRed.text = RedPoint.ToString();
            NumFire.text = FirePoint.ToString();
        }
    }
    public void RedMinus(){
        if (RedPoint > 0){
            RedPoint -= 1;
            FirePoint += 1;
            NumRed.text = RedPoint.ToString();
            NumFire.text = FirePoint.ToString();
        }
    }
    public void GreenPlus(){
        if (FirePoint > 0){
            GreenPoint += 1;
            FirePoint -= 1;
            NumGreen.text = GreenPoint.ToString();
            NumFire.text = FirePoint.ToString();
        }
    }
    public void GreenMinus(){
        if (GreenPoint > 0){
            GreenPoint -= 1;
            FirePoint += 1;
            NumGreen.text = GreenPoint.ToString();
            NumFire.text = FirePoint.ToString();
        }
    }
    public void GreyPlus(){
        if (FirePoint > 0){
            GreyPoint += 1;
            FirePoint -= 1;
            NumGrey.text = GreyPoint.ToString();
            NumFire.text = FirePoint.ToString();
        }
    }
    public void GreyMinus(){
        if (GreyPoint > 0){
            GreyPoint -= 1;
            FirePoint += 1;
            NumGrey.text = GreyPoint.ToString();
            NumFire.text = FirePoint.ToString();
        }
    }
    public void YellowPlus(){
        if (FirePoint > 0){
            YellowPoint += 1;
            FirePoint -= 1;
            NumYellow.text = YellowPoint.ToString();
            NumFire.text = FirePoint.ToString();
        }
    }
    public void YellowMinus(){
        if (YellowPoint > 0){
            YellowPoint -= 1;
            FirePoint += 1;
            NumYellow.text = YellowPoint.ToString();
            NumFire.text = FirePoint.ToString();
        }
    }
    public void TimePlus(){
        if (TimePoint > 0){
            SecondPoint += 1;
            TimePoint -= 1;
            NumSecond.text = SecondPoint.ToString();
            NumTime.text = TimePoint.ToString();
        }
    }
    public void TimeMinus(){
        if (SecondPoint > 0){
            SecondPoint -= 1;
            TimePoint += 1;
            NumSecond.text = SecondPoint.ToString();
            NumTime.text = TimePoint.ToString();
        }
    }
    public void ResetDefaultSetting(){
        FirePoint = 8;
        TimePoint = 5;

        RedPoint = 1;
        GreenPoint = 1;
        YellowPoint = 1;
        GreyPoint = 1;
        SecondPoint = 10;

        NumFire.text = FirePoint.ToString();
        NumTime.text = TimePoint.ToString();

        NumRed.text = RedPoint.ToString();
        NumGreen.text = GreenPoint.ToString();
        NumGrey.text = GreyPoint.ToString();
        NumYellow.text = YellowPoint.ToString();
        NumSecond.text = SecondPoint.ToString();

        Mode.isOn = true;
    }
    public void BackToMainMenu(){
        Mainmenu.SetActive(true);
        Setting.SetActive(false);
    }
    public void GotoSetting(){
        Setting.SetActive(true);
        Mainmenu.SetActive(false);
        
    }
    public void ChangeMode(bool Timemode){
        if (Timemode == true){
            SettingTime.SetActive(true);
            PointTime.SetActive(true);
            GameMode = true;
        }else{
            SettingTime.SetActive(false);
            PointTime.SetActive(false);
            GameMode = false;
        }
    }
}
