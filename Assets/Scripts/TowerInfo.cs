using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo
{
    public int towerId = 0;
    public TowerData data => Configs.Ins.GetTower(towerId);
    public int level = 0;
    public int hp = 100;
    public TowerInfo(int towerId, int level)
    {
        this.towerId = towerId;
        this.level = level;
        this.hp = data.Hp;
    }
}
