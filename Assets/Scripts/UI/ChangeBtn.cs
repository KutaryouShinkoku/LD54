using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBtn : MonoBehaviour
{
    [SerializeField] Sprite common;
    [SerializeField] Sprite selected;
    [SerializeField] Image target;
    // Start is called before the first frame update
    void Start()
    {
        //target.sprite = common;
    }
    public void onSelect()
    {
        target.sprite = selected;
    }
    public void onCommon()
    {
        target.sprite = common;
    }

}
