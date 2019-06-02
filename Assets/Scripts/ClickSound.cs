using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public bool click { get; set; }
    public AudioClip[] clickSounds;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (click)
        {
            sound.PlayOneShot(clickSounds[Random.Range(0, clickSounds.Length)]);
            click = false;
        }
    }
}
