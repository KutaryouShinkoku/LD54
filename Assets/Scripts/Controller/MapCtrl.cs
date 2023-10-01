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
    private Vector2 zeroPos => leftDown.position;
    public Grid[,] grids = null;
    [UnityEditor.MenuItem("Map/Generate")]
    public static void GenerateMap()
    {
        Ins.InitMap();
    }
    public void InitMap()
    {
        ClearMap();
        grids = new Grid[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                bool isFertile = !(j == 0 || j == height - 1);
                GameObject grid = Res.Ins.gridPrefab.OPGet();
                grid.transform.SetParent(gridFolder);
                grid.transform.position = leftDown.position + new Vector3(i * gridSize.x, j * gridSize.y, 0);
                Vector2Int crd = new Vector2Int(i,j);
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
}
