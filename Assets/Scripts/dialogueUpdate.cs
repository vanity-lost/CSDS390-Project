using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueUpdate : MonoBehaviour
{
    public Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "Background Story...";
    }

    // Update is called once per frame
    void Update()
    {
        dialogueText.text = "Background Story...";
    }
}
