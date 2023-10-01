using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configs : Singleton<Configs>
{
    [SerializeField]
    private List<TowerData> towerCfg;
    public TowerData GetTower(int id)
    {
        return towerCfg.Find(e => e.Id == id);
    }
}
