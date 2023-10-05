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
    private List<RoundData> _loopRound;

    [SerializeField]
    private List<TowerData> _towerData;
    [SerializeField]
    private List<ProjectileData> _projectileData;

    [Header("敌人行进速度")]
    public float enemySpeed = 0.3f;

    [Header("弹幕飞行速度")]
    public float projectileSpeed = 2f;

    [Header("防御塔攻击间隔")]
    public float towerAtkInterval = 0.85f;

    [Header("丰沃土地每秒产出")]
    public int fertileIncome = 1;
    [Header("丰沃土地产出时间间隔")]
    public float fertileIncomeTime = 5;
    [Header("防御塔伤害")]
    public float towerDamage = 20f;
    [Header("敌人伤害")]
    public float enemyDamage = 20f;
    [Header("防御塔基本造价")]
    public int baseTowerCost = 50;
    [Header("场上每多一个防御塔的额外造价")]
    public int addTowerCost = 30;
    [Header("场上每多一个防御塔的二次提升")]
    public int addTowerCost2 = 30;
    [Header("防御塔每多一个非己供能装置的攻速增益")]
    public float addTowerAtkSpeed = 0.7f;

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
    public bool isInLoopRound(int round)
    {
        return round - 1 >= _enemyCreatorData.Count;
    }
    public RoundData GetRoundData(int round)
    {
        if (isInLoopRound(round))
        {
            return _loopRound[(round - 1 - _enemyCreatorData.Count) % _loopRound.Count];
        }
        else
            return _enemyCreatorData.Find(o => o.round == round);
    }
    public TowerData GetTowerData(int id)
    {
        return _towerData.Find(o => o.Id == id);
    }
    public ProjectileData GetProjectileData(int id)
    {
        return _projectileData.Find(o => o.Id == id);
    }
}
