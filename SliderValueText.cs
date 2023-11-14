using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderValueText : MonoBehaviour{
    //[SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Text volumeTextUI = null;
    public static int NumberOfEvent;
    void Start(){
        NumberOfEvent = 1;
    }
    public void VolumeSlider(float volume){
        volumeTextUI.text = volume.ToString("0");
        NumberOfEvent = Mathf.FloorToInt(volume);
        Debug.Log(NumberOfEvent);
    }
}
