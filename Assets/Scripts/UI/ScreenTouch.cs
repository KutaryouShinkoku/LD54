using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ScreenTouch : Singleton<ScreenTouch>, IPointerDownHandler
{
    private Action downEvent;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        downEvent?.Invoke();
        downEvent = null;
        gameObject.SetActive(false);
    }

    public void SetData(Action downEvent)
    {
        gameObject.SetActive(true);
        this.downEvent = downEvent;
    }
}
