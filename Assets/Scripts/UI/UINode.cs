using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINode : MonoBehaviour
{
    [SerializeField]
    private bool active = false;
    protected void Awake()
    {
        UI.Ins.RegistNode(this);
    }
    protected void Start()
    {
        gameObject.SetActive(active);
    }

}
