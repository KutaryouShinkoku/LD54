using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{

    [SerializeField]
    public Transform creatorRoot;
    private RoundData _enemyCreatorData => GameManager.Ins._enemyCreatorData;
    private bool active = false;
    //public int 
    // Use this for initialization
    void Start()
    {
        time = Random.Range(_enemyCreatorData.minCreateTime, _enemyCreatorData.maxCreateTime);
    }
    // Update is called once per frame
    private float time;
    /// <summary>
    /// 本轮要刷出的敌人数量
    /// </summary>
    private int enemyRemain = 0;
    public void StartCreate()
    {
        active = true;
        time = -1;
        enemyRemain = _enemyCreatorData.EnemyCnt;
    }
    public void StopCreate()
    {
        active = false;
    }
    private void FinishCreate()
    {
        active = false;
        GameManager.Ins.FinishWave();
    }
    void Update()
    {
        if (!active)
            return;
        if (time < 0)
        {
            GenerateEnemy();
            enemyRemain--;
            time = Random.Range(_enemyCreatorData.minCreateTime, _enemyCreatorData.maxCreateTime);
        }
        else
        {
            time -= Time.deltaTime;
        }
        if (enemyRemain <= 0)
        {
            FinishCreate();
        }

    }
    private void GenerateEnemy()
    {
        //生成敌人 
        GameObject enemy = Res.Ins.enemyPrefab.OPGet();
        enemy.transform.SetParent(creatorRoot);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        List<int> pathIds = new List<int>();
        for (int i = 0; i < MapCtrl.Ins.paths.Length; i++)
        {
            pathIds.Add(MapCtrl.Ins.paths[i].pathId);
        }
        float totalLevelWei = _enemyCreatorData.lv1 + _enemyCreatorData.lv2 + _enemyCreatorData.lv3;
        float rand = Random.Range(0, totalLevelWei);
        int level = 0;
        if (rand < _enemyCreatorData.lv1)
        {
            level = _enemyCreatorData.BaseLevel;
        }
        else if (rand < _enemyCreatorData.lv1 + _enemyCreatorData.lv2)
        {
            level = _enemyCreatorData.BaseLevel + 1;
        }
        else
        {
            level = _enemyCreatorData.BaseLevel + 2;
        }
        enemyScript.Init(Random.Range(0, 1) > 0.5 ? AttackType.Air : AttackType.Ground, new Vector2Int(MapCtrl.Ins.width - 1, pathIds[Random.Range(0, pathIds.Count)]), level);
        //int level = 
        //enemyScript.Init(AttackType.All, _creatorRoot, 3);
        MapCtrl.Ins.AddEnemy(enemyScript);

    }
}
