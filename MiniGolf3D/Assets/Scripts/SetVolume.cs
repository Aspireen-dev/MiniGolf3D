using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    Slider slider;
    public AudioSource musicAudioSource;

    private void Start()
    {
        slider = GetComponent<Slider>();
        musicAudioSource = BackgroundMusic.Instance.GetComponent<AudioSource>();

        float volume = PlayerPrefs.GetFloat("volume");
        if (volume == 0) volume = 0.2f;

        slider.value = volume;
        SetMusicVolume();
    }

    public void SetMusicVolume()
    {
        float volume = slider.value;
        PlayerPrefs.SetFloat("volume", volume);
        musicAudioSource.volume = volume;
    }
}
