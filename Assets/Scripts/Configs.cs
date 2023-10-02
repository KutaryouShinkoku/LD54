using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configs : Singleton<Configs>
{
    [SerializeField]
    private List<TowerData> towerCfg;
    [SerializeField]
    private List<EnemyData> _enemyCfg;
    [Header("敌人行进速度")]
    public float enemySpeed = 1f;
    [Header("弹幕飞行速度")]
    public float projectileSpeed = 2f;
    [Header("防御塔攻击间隔")]
    public float towerAtkInterval = 0.7f;
    [Header("丰沃土地每秒产出")]
    public float fertileIncome = 1f;
    public TowerData GetTower(int id)
    {
        return towerCfg.Find(e => e.Id == id);
    }
    public EnemyData GetEnemy(AttackType enemyType)
    {
        return _enemyCfg.Find(o => o.enemyType == enemyType);
    }

}
