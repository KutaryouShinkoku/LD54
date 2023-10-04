using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragModeToggle : MonoBehaviour
{
    public void OnSwitchToggle()
    {
        U_TowerSlotGrp.dragMode = GetComponent<UnityEngine.UI.Toggle>().isOn;
    }
}
