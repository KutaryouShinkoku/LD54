using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperateCtrl : Singleton<OperateCtrl>
{
    private MapCtrl map => MapCtrl.Ins;
    public Transform targetImg;
    public Vector2 mousePos
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    public void EnterPlace(int towerId)
    {

    }
    public void ExitPlace(int towerId)
    {

    }
    public void UpdatePlace(int towerId)
    {

    }
}
