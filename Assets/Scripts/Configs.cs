using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configs : Singleton<Configs>
{
    [SerializeField]
    private List<TowerData> towerCfg;

    [SerializeField]
    private List<EnemyData> _enemyCfg;

    [SerializeField]
    private List<RoundData> _enemyCreatorData;

    [SerializeField]
    private List<TowerData> _towerData;

    [Header("敌人行进速度")]
    public float enemySpeed = 0.3f;

    [Header("弹幕飞行速度")]
    public float projectileSpeed = 2f;

    [Header("防御塔攻击间隔")]
    public float towerAtkInterval = 0.7f;

    [Header("丰沃土地每秒产出")]
    public int fertileIncome = 1;
    [Header("防御塔伤害")]
    public float towerDamage = 20f;
    [Header("敌人伤害")]
    public float enemyDamage = 20f;

    //[SerializeField]
    //private EnemyCreatorData _enemyCreatorData;
    public TowerData GetTower(int id)
    {
        return towerCfg.Find(e => e.Id == id);
    }

    public EnemyData GetEnemy(AttackType enemyType)
    {
        return _enemyCfg.Find(o => o.enemyType == enemyType);
    }

    /**
     *
     */
    public RoundData GetEnemyCreatorData(float round)
    {
        return _enemyCreatorData.Find(o => o.round == round);
    }
    public TowerData GetTowerData(int id)
    {
        return _towerData.Find(o => o.Id == id);
    }
}
