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
    private List<EnemyCreatorData> _enemyCreatorData;
    public TowerData GetTower(int id)
    {
        return towerCfg.Find(e => e.Id == id);
    }
    public EnemyData getEnemy(EEnemyType enemyType)
    {
        return _enemyCfg.Find(o => o.enemyType == enemyType);
    }
    /**
     * 
     */
    public EnemyCreatorData GetEnemyCreatorData(float round)
    {
        return _enemyCreatorData.Find(o => o.round == round);
    }
}
