using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : Singleton<MapCtrl>
{
    public int width;   //地图宽度（块数）
    public int height;  //地图高度（块数）
    public Vector2 gridSize = new Vector2(20, 20);
    public Transform leftDown;
    public Transform gridFolder;
    public Transform projectileFolder;
    private Vector2 zeroPos => leftDown.position;
    public Transform maxRightPos;
    public Transform maxLeftPos;
    public float maxRight => maxRightPos.position.x;
    public float maxLeft => maxLeftPos.position.x;

    //======================结构数据====================//
    /// <summary>
    /// 路径信息
    /// </summary>
    public PathInfo[] paths = null;
    public Grid[,] grids = null;
    public List<TowerObj> towers = new List<TowerObj>();
    public List<Enemy> enemies = new List<Enemy>();
    //=================================================//
    public PathInfo GetPathByCrd(Vector2Int crd)
    {
        for (int i = 0; i < paths.Length; i++)
        {
            if (crd.y == paths[i].pathId)
            {
                return paths[i];
            }
        }
        return null;
    }
    public PathInfo GetPathById(int pathId)
    {
        for (int i = 0; i < paths.Length; i++)
        {
            if (paths[i].pathId == pathId)
                return paths[i];

        }
        return null;
    }
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Map/Generate")]
    public static void GenerateMap()
    {
        Ins.InitMap();
    }
#endif
    public void InitMap()
    {
        ClearMap();
        grids = new Grid[width, height];
        paths = new PathInfo[height - 2];
        towers = new List<TowerObj>();
        enemies = new List<Enemy>();
        for (int j = 0; j < height; j++)
        {
            bool isFertile = !(j == 0 || j == height - 1);
            if (isFertile)
                paths[j - 1] = new PathInfo(j, width - 1);
            for (int i = 0; i < width; i++)
            {
                if (i > width - 2)
                    isFertile = false;
                GameObject grid = Res.Ins.gridPrefab.OPGet();
                grid.transform.SetParent(gridFolder);
                grid.transform.position = leftDown.position + new Vector3(i * gridSize.x, j * gridSize.y, 0);
                Vector2Int crd = new Vector2Int(i, j);
                Grid com = grid.GetComponent<Grid>();
                com.Init(isFertile);
                grids[crd.x, crd.y] = com;
                com.crd = crd;
            }
        }
    }
    private void ClearMap()
    {
        List<Transform> childs = new List<Transform>();
        for (int i = 0; i < gridFolder.childCount; i++)
        {
            childs.Add(gridFolder.GetChild(i));
        }
        for (int i = 0; i < childs.Count; i++)
        {
            childs[i].gameObject.OPPush();
        }
    }
    public Vector2Int Pos2crd(Vector2 pos)
    {
        Vector2 diff = pos - zeroPos;
        return new Vector2Int(Mathf.RoundToInt(diff.x / gridSize.x), Mathf.RoundToInt(diff.y / gridSize.y));
    }
    public Vector2 Crd2Pos(Vector2Int crd)
    {
        return zeroPos + new Vector2(crd.x * gridSize.x, crd.y * gridSize.y);
    }
    public Vector2 SnappedPos(Vector2 pos)
    {
        return Crd2Pos(Pos2crd(pos));
    }
    public Grid GetGrid(Vector2Int crd)
    {
        if (!ValidCrd(crd))
            return null;
        else
            return grids[crd.x, crd.y];
    }
    public bool ValidCrd(Vector2Int crd)
    {
        if (crd.x < 0 || crd.x >= width || crd.y < 0 || crd.y >= height)
            return false;
        return true;
    }
    public Grid GetGridByPos(Vector2 pos)
    {
        return GetGrid(Pos2crd(pos));
    }
    public void PlaceTower(int towerId, Vector2Int targetCrd)
    {
        Debug.Log("place" + towerId + "at" + targetCrd);
        TowerObj tower = Res.Ins.towerPrefab.OPGet().GetComponent<TowerObj>();
        Grid targetGrid = GetGrid(targetCrd);
        tower.transform.SetParent(targetGrid.towerFolder);
        tower.Init(towerId, targetCrd);
        List<Vector2Int> crdList = tower.data.Links;
        for (int i = 0; i < crdList.Count; i++)
        {
            Grid grid = GetGrid(targetCrd + crdList[i]);
            grid.Occupied(tower);
        }
        GetPathByCrd(targetCrd).AddTower(tower);
        GameManager.Ins.energy -= Configs.Ins.cost;
    }
    public void DestoryTower(TowerObj tower)
    {
        GetPathByCrd(tower.centerCrd).RemoveTower(tower);

        List<Vector2Int> crdList = tower.data.Links;
        for (int i = 0; i < crdList.Count; i++)
        {
            Grid grid = GetGrid(tower.centerCrd + crdList[i]);
            grid.CancelOccupied();
        }
        tower.gameObject.OPPush();

    }
    /// <summary>
    /// 添加生成的敌人
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="pathId">第几路，范围1～4</param>
    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        GetPathByCrd(enemy.crd).AddEnemy(enemy);
    }
    public void KillEnemy(Enemy enemy)
    {
        GetPathByCrd(enemy.crd).RemoveEnemy(enemy);

    }
}
