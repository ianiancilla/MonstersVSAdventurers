using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] float startDelay = 1f;
    // cache
    AudioSource audioSource;

    void Start()
    {
        DontDestroyOnLoad(this);

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
        audioSource.PlayDelayed(startDelay);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
