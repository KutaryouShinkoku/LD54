using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragModeToggle : MonoBehaviour
{
    public void OnSwitchToggle()
    {
        TowerSlotGrp.dragMode = GetComponent<UnityEngine.UI.Toggle>().isOn;
    }
}
