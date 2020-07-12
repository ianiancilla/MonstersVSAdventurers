using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [Header ("Volume")]
    [SerializeField] Slider volumeSlider;

    [Header("Difficulty")]
    [SerializeField] Slider difficultySlider;


    // cache
    MusicPlayer musicPlayer;

    private void Start()
    {
        // cache
        musicPlayer = FindObjectOfType<MusicPlayer>();

        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        HandleMusicSlider();
    }

    private void HandleMusicSlider()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found.");
        }
    }


    public void SaveAndExit()
    {
        // volume
        var volume = volumeSlider.value;
        PlayerPrefsController.SetMasterVolume(volume);

        // difficulty
        var difficulty = difficultySlider.value;
        PlayerPrefsController.SetDifficulty(difficulty);

        FindObjectOfType<SceneLoader>().LoadStart();
    }

    public void BackToDefault()
    {
        volumeSlider.value = PlayerPrefsController.GetDefaultVolume();
        difficultySlider.value = PlayerPrefsController.GetDefaultDifficulty();

    }

}
