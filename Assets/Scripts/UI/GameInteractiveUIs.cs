using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInteractiveUIs : MonoBehaviour
{
    [SerializeField] GameObject _uISettings;


    private bool isSettingOpen;

    public void Start()
    {
        isSettingOpen = false;
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
