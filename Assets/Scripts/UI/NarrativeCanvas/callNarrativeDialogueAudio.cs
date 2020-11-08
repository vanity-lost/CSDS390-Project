using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callNarrativeDialogueAudio : MonoBehaviour
{
    public AudioClip lines1;
    public AudioClip lines2;
    public AudioClip lines3;
    public AudioClip lines2_1;
    public AudioClip lines2_2;
    public AudioClip lines2_3;
    public AudioClip lines3_1;
    public AudioClip lines3_2;
    public AudioClip lines3_3;

    public AudioSource DialogueSounds;

    // Start is called before the first frame update
    void Start()
    {
        DialogueSounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playSound()
    {

    }

}
