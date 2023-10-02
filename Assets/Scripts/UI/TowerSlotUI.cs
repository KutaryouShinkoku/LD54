using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ETowerSlotType { buy, upgrade };
public class TowerSlotUI : MonoBehaviour
{
    [SerializeField] private int _id;
    private int _level;
    private TowerData _towerData;
    [SerializeField] Text _cost;
    private void Start()
    {
        _towerData = Configs.Ins.GetTowerData(_id);
        _level = _towerData.level;
        onRefresh();
    }

    public int level
    {
        get { return _level; }
        set
        {
            _level = value;
            onRefresh();
        }
    }
    public void onRefresh()
    {
        switch (GameManager.Ins.towerSlotType)
        {
            case ETowerSlotType.buy:
                _cost.text = "" + _towerData.buyCost[_level];

                break;
            case ETowerSlotType.upgrade:
                _cost.text = "" + _towerData.upgradeCost[_level];
                break;
        }

    }
}
