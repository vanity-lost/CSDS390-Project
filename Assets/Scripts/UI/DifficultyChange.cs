using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyChange : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Text ValueText;

    private void Start()
    {
        GlobalData.MENACE_METER = 1000;
        ValueText = GetComponent<Text>();
        
    }

    public void Update() {
        Debug.Log(GlobalData.MENACE_METER);
    }

    public void OnSliderValueChanged(float value)
    {
        GlobalData.MENACE_METER = value;
        if(GlobalData.MENACE_METER >= 200 && GlobalData.MENACE_METER <= 800) {
            ValueText.text = "impossible";
        } else if (GlobalData.MENACE_METER > 800 && GlobalData.MENACE_METER <= 1800) {
            ValueText.text = "Hard";
        } else if (GlobalData.MENACE_METER > 1800 && GlobalData.MENACE_METER <= 3200) {
            ValueText.text = "Medium";
        } else {
            ValueText.text = "Easy";
        }
    }
}
