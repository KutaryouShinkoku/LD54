using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _uICredits;
    [SerializeField] GameObject _uISettings;
    

    private bool isSettingOpen;

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
        if (isSettingOpen == true)
        {
            _uISettings.SetActive(false);
            isSettingOpen = false;
        }
        else
        {
            _uISettings.SetActive(true);
            isSettingOpen = true;
        }
    }


}
