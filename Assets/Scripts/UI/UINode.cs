using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINode : MonoBehaviour
{
    [SerializeField]
    private bool active = false;
    protected virtual void Awake()
    {
        UI.Ins.RegistNode(this);
    }
    protected virtual void Start()
    {
        gameObject.SetActive(active);
    }

}
