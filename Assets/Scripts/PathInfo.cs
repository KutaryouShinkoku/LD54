using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathInfo
{
    /// <summary>
    /// 路径上的敌人,第0个元素为前线敌人（最左边的敌人）
    /// </summary>
    public List<Enemy> enemies = new List<Enemy>();
    /// <summary>
    /// 路径上的防御设施，第0个元素为前线防御设施（最右边的防御设施）
    /// </summary>
    public List<TowerObj> towers = new List<TowerObj>();
    /// <summary>
    /// 最远处的x坐标
    /// </summary>
    private int _maxRight;
    public List<Grid> grids
    {
        get
        {
            Grid[,] allGrids = MapCtrl.Ins.grids;
            List<Grid> res = new List<Grid>();
            for (int i = 0; i < allGrids.GetLength(0); i++)
            {
                for (int j = 0; j < allGrids.GetLength(1); j++)
                {
                    if (allGrids[i, j].crd.y == pathId)
                    {
                        res.Add(allGrids[i, j]);
                    }
                }
            }
            return res;
        }
    }
    public int maxRight => _maxRight;
    /// <summary>
    /// 该路径所在的y坐标
    /// </summary>
    private int _pathId;
    public int pathId => _pathId;
    public PathInfo(int pathId, int maxRight)
    {
        this._pathId = pathId;
        this._maxRight = maxRight;
    }
    public void AddEnemy(Enemy enemy)
    {
        bool flag = true;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].crd.x > enemy.crd.x)
            {
                enemies.Insert(i, enemy);
                flag = false;
                break;
            }
        }
        if (flag)
            enemies.Add(enemy);
        SendChange();
    }
    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        SendChange();
    }

    public void AddTower(TowerObj tower)
    {
        bool flag = true;
        for (int i = 0; i < towers.Count; i++)
        {
            if (towers[i].centerCrd.x < tower.centerCrd.x)
            {
                towers.Insert(i, tower);
                flag = false;
                break;
            }
        }
        if (flag)
            towers.Add(tower);
        SendChange();
    }
    public void RemoveTower(TowerObj tower)
    {
        towers.Remove(tower);
        SendChange();
    }
    public Enemy GetFrontEnemy(AttackType type = AttackType.All)
    {
        return enemies.Find(e => type == AttackType.All || e.data.enemyType == type);
    }
    public void SendChange()
    {
        towers.ForEach(e => e.OnPathInfoChanged());
        enemies.ForEach(e => e.OnPathInfoChanged());
        grids.ForEach(e => e.isColonized = IsInColonized(e.crd));
    }
    public bool IsInColonized(Vector2Int crd)
    {
        return frontLine <= crd.x;
    }
    public void OnEnemyMoveNext()
    {
        grids.ForEach(e => e.isColonized = IsInColonized(e.crd));

    }

    /// <summary>
    /// 最前线的飞行敌人
    /// </summary>
    public Enemy frontAirEnemy => enemies.Find(e => e.data.enemyType == AttackType.Air);
    /// <summary>
    /// 最前线的地面敌人
    /// </summary>
    public Enemy frontGroundEnemy => enemies.Find(e => e.data.enemyType == AttackType.Ground);
    /// <summary>
    /// 最前线的敌人的x坐标
    /// </summary>
    public int frontLine => enemies.Count == 0 ? maxRight : enemies[0].crd.x;

}
