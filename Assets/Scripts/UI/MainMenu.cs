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
    //��ʼ��Ϸ
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //������Ϸ
    public void ExitGame()
    {
        Application.Quit();
    }
    //��Credits
    public void ShowCredits()
    {
        _uICredits.SetActive(true);
    }
    //�ر�Credits
    public void CloseCredits()
    {
        _uICredits.SetActive(false);
    }
    //�򿪻�ر�����
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
