using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//拖拽防御塔的交互
public class TowerSlot : MonoBehaviour
{
    public int towerId;
    public void UpgradeTower()
    {
        GameManager.Ins.UpgradeTower(towerId);
    }
}
