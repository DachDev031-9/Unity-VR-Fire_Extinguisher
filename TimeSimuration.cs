using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeSimuration : MonoBehaviour{
    public static int Time, Total;
    public static bool GreyZone, GreenZone, YellowZone, RedZone;
    bool ChackGreyZone, ChackGreenZone, ChackYellowZone, ChackRedZone;
    [SerializeField] private Text uiText;
    private int remainingDuration;
    public GameObject Timebar;
    void Start(){
        GreyZone = false;
        YellowZone = false;
        GreenZone = false;
        RedZone = false;
        ChackGreyZone = false;
        ChackGreenZone = false;
        ChackYellowZone = false;
        ChackRedZone = false;
        Time = SettingGame.SecondPoint * 60;
        if (SettingGame.GameMode == true){
            Timebar.SetActive(true);
        }else{
            Timebar.SetActive(false);
        }
    }
    void Update(){
        if (GreyZone == true && ChackGreyZone == false){
            Time += 30;
            ChackGreyZone = true;
        }else if (YellowZone == true && ChackYellowZone == false){
            Time += 30;
            ChackYellowZone = true;
        }else if (GreenZone == true && ChackGreenZone == false){
            Time += 30;
            ChackGreenZone = true;
        }else if (RedZone == true && ChackRedZone == false){
            Time += 30;
            ChackRedZone = true;
        }
        Being(Time);
    }
    private void Being(int Second){
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer(){
        while(remainingDuration >= 0){
            uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
            yield return new WaitForSeconds(1f);
        }
    }
}
