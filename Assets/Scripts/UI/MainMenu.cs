using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _uICredits;
    [SerializeField] GameObject _uISettings;
    [SerializeField] Slider _volumeSlider;

    private bool isSettingOpen;
    public float volumeValue;

    public void Start()
    {
        isSettingOpen = false;
    }
    //开始游戏
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //结束游戏
    public void ExitGame()
    {
        Application.Quit();
    }
    //打开Credits
    public void ShowCredits()
    {
        _uICredits.SetActive(true);
    }
    //关闭Credits
    public void CloseCredits()
    {
        _uICredits.SetActive(false);
    }
    //打开或关闭设置
    public void ShowSettings()
    {
        _volumeSlider.value = volumeValue;
        if (isSettingOpen == true)
        {
            _uISettings.SetActive(false);
            isSettingOpen = false;
        }
        else
        {
            _uISettings.SetActive(true);
            isSettingOpen = true;
            //SaveVolume();
        }
    }
    //调节音量,有需要再加
    //public void VolumeSlider(float volume)
    //{
    //    volumeValue = volume;
    //}

    //public void SaveVolume()
    //{
    //    volumeValue = _volumeSlider.value;
    //    PlayerPrefs.SetFloat("VolumeValue", volumeValue);
    //    LoadValues();
    //}

    //public void LoadValues()
    //{
    //    volumeValue = PlayerPrefs.GetFloat("VolumeValue");
    //    _volumeSlider.value = volumeValue;
    //    AudioListener.volume = volumeValue;
    //}
}
