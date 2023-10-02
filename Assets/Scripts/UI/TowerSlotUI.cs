using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ETowerSlotType { buy, upgrade };
public class TowerSlotUI : MonoBehaviour
{
    [SerializeField] private int _id;
    private int _level => GameManager.Ins.GetTowerLevel(_id);
    private TowerData _towerData => Configs.Ins.GetTowerData(_id);
    [SerializeField] Text _cost;
    private void Start()
    {
        onRefresh();
    }

    public void onRefresh()
    {
        Debug.Log(_towerData);
        switch (GameManager.Ins.towerSlotType)
        {
            case ETowerSlotType.buy:
                // _cost.text = "" + _towerData.buyCost[_level];
                _cost.text = "" + Configs.Ins.cost;

                break;
            case ETowerSlotType.upgrade:
                _cost.text = "" + Configs.Ins.cost;
                break;
        }

    }
}
