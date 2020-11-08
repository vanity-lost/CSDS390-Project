using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callNarrativeDialogueAudio : MonoBehaviour
{
    public AudioClip lines1;
    public AudioClip lines2;
    public AudioClip lines3;

    public AudioSource[] DialogueSounds;

    // Start is called before the first frame update
    void Start()
    {
        DialogueSounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
