using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int round = 1;
    public int energy = 0;
    private float waveTimer = 0;
    private bool isInPrepare = false;
    public RoundData roundData => Configs.Ins.GetEnemyCreatorData(round);
    public EnemyCreator enemyCreator;
    public ETowerSlotType towerSlotType;

    public void AddEnergy(int energy)
    {
        this.energy += energy;
        // EC.Send(EC.UPDATE_ENERGY);
    }

    private void Start()
    {
        InitGame();
    }

    public void InitGame()
    {
        round = 1;
        energy = 0;
        StartWave();
        towerSlotType = ETowerSlotType.buy;
        MapCtrl.Ins.InitMap();
    }

    /// <summary>
    /// 玩家的防御设施升级状况   key: towerId, value: level
    /// </summary>
    private Dictionary<int, int> towerLevelMap = new Dictionary<int, int>();

    public int GetTowerLevel(int towerId)
    {
        if (towerLevelMap.ContainsKey(towerId))
        {
            return towerLevelMap[towerId];
        }
        return 0;
    }

    /// <summary>
    /// 结束进攻波次
    /// </summary>
    public void FinishWave()
    {
        round++;
        StartWave();
    }

    private void StartWave()
    {
        waveTimer = 0;
        isInPrepare = true;
    }

    private void Update()
    {
        if (!isInPrepare)
            return;
        if (waveTimer >= roundData.PrepareTime)
        {
            enemyCreator.StartCreate();
            isInPrepare = false;
        }
        Debug.Log("waveTimer:" + waveTimer);
        waveTimer += Time.deltaTime;
    }

    public void UpgradeTower(int towerId)
    {
        if (towerLevelMap.ContainsKey(towerId))
        {
            towerLevelMap[towerId]++;
        }
        EC.Send(EC.UPGRADE_TOWER);
    }

    public void Win() { }

    public void Lose() { }
}
