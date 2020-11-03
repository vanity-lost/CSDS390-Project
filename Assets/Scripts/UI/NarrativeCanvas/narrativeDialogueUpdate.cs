using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class narrativeDialogueUpdate : MonoBehaviour
{
    public TextMeshProUGUI _narrativeDialogue;
    public TextMeshProUGUI _continueHints;

    public string[] messages;

    public int currentMessageIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _narrativeDialogue.SetText(messages[currentMessageIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
