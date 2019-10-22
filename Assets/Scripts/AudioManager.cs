using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
   
    // Reference to the AudioSource
    public AudioSource audioSource;
    // References the song clip
    public AudioClip song;
    // References a perfectly loopable version of the song
    // (for songs with intros not to be repeated)
    public AudioClip loopable;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        //Singleton stuffs
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        // If there is no loopable given, just use the full song
        if (loopable == null)
            loopable = song;

        // Gets AudioSource
        audioSource = GetComponent<AudioSource>();

        // Makes it so it doesn't loops
        audioSource.loop = false;

        // Sets the clip
        audioSource.clip = song;
        // Plays it
        audioSource.Play();
    }

    private void Update()
    {
        // Once it has gone through the song once
        if(audioSource.isPlaying == false)
        {
            // Set the clip to the loopable
            audioSource.clip = loopable;
            // Make it loop
            audioSource.loop = true;
            // Play the clip
            audioSource.Play();
        }
    }
}
