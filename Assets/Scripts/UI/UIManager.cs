using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] List<TowerSlotUI> _towerSlot1;
    [SerializeField] Text _energyCount;
    public void Update()
    {
        _energyCount.text = "" + GameManager.Ins.energy;
    }
    public void onClickChangeUpgrade()
    {
        if (GameManager.Ins.towerSlotType == ETowerSlotType.upgrade) return;
        GameManager.Ins.towerSlotType = ETowerSlotType.upgrade;
        _towerSlot1.ForEach(tower =>
        {
            tower.onRefresh();
        });
    }
    public void onClickChangeBuy()
    {
        if (GameManager.Ins.towerSlotType == ETowerSlotType.buy) return;
        GameManager.Ins.towerSlotType = ETowerSlotType.buy;
        _towerSlot1.ForEach(tower =>
        {
            tower.onRefresh();
        });
    }
}
