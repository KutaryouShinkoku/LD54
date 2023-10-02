using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    private AttackType enemyType;
    public EnemyData data => Configs.Ins.GetEnemy(enemyType);
    private int level = 0;
    public void Init(AttackType type, Vector2Int crd, int level)
    {
        this.enemyType = type;
        this.crd = crd;
        progress = 0;
        this.level = level;
    }
    /// <summary>
    /// 敌人当前所属格子
    /// </summary>
    public Vector2Int crd;
    /// <summary>
    /// 敌人前往下一个格子的行进进度
    /// </summary>
    public float progress;
    private MapCtrl map => MapCtrl.Ins;
    public Vector2 pos => Vector2.Lerp(map.Crd2Pos(crd), map.Crd2Pos(crd + Vector2Int.left), progress);

    void Update()
    {
        progress += Time.deltaTime * Configs.Ins.enemySpeed;
        if (progress >= 1)
        {
            progress = 0;
            crd += Vector2Int.left;
        }
        transform.position = pos;
    }
    public void OnPathInfoChanged()
    {

    }
    public void Attacked()
    {

    }
}

