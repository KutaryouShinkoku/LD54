using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumManager : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;

    public void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            LoadValues();
        }
        else
        {
            LoadValues();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = _volumeSlider.value;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", _volumeSlider.value);
        LoadValues();
    }

    public void LoadValues()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
