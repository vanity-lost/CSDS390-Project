using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Loading : MonoBehaviour
{
    public TextMeshProUGUI _loadingText;
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        _loadingText.SetText("Loading...|");
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5f) {
            _loadingText.SetText("Loading.../");
        } else if (timer > 1f) {
            _loadingText.SetText("Loading...-");
        } else if (timer > 0.5f) {
            _loadingText.SetText("Loading...\\");
        }
    }
}
