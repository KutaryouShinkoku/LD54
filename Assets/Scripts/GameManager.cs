using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int round = 1;
    public int money = 0;
    private float waveTimer = 0;
    public RoundData roundData => Configs.Ins.GetEnemyCreatorData(round);
    public void InitGame()
    {
        round = 1;
        money = 0;
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

    }
    private void StartWave()
    {
        RoundData roundData
    }
    private void Update()
    {

    }
    public void UpgradeTower(int towerId)
    {
        if (towerLevelMap.ContainsKey(towerId))
        {
            towerLevelMap[towerId]++;
        }
        EC.Send(EC.UPGRADE_TOWER);
    }
}
