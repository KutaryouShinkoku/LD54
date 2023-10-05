using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatioFixer : MonoBehaviour
{
    public Vector2 size = new Vector2(1920, 1080);
    //以1920x1080为基准，屏幕根据高度的不同等比例缩放，适配控件的大小
    public void RectAdaptY(RectTransform rect)
    {
        float scale = Screen.height / size.y;
        Debug.Log("scale = " + scale);
        rect.sizeDelta = new Vector2(scale, scale) * rect.sizeDelta;
    }

    //以1920x1080为基准，屏幕根据宽度的不同等比例缩放，适配控件的大小
    public void RectAdaptX(RectTransform rect)
    {
        float scale = Screen.width / size.x;
        rect.sizeDelta = new Vector2(scale, scale) * rect.sizeDelta;
    }

}
