using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EPreviewState
{
    Access,
    Occupied,
    OutOfEdge,
    CantBePlaced,
    Colonized,
}
public class OperateCtrl : Singleton<OperateCtrl>
{
    public Transform test;
    private List<Grid> previewGrids = new List<Grid>();
    private MapCtrl map => MapCtrl.Ins;
    public Vector2 mousePos => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    public void EnterPlace(int towerId)
    {

    }
    public void ExitPlace(int towerId)
    {
        EPreviewState res = PreviewByMouse(towerId);
        switch (res)
        {
            case EPreviewState.Access:
                map.PlaceTower(towerId, map.GetGridByPos(mousePos).crd);
                break;
            case EPreviewState.Occupied:
                UI.Ins.Get<U_OperateTips>().SetData("摆放位置已被占用");
                break;
            case EPreviewState.OutOfEdge:
                UI.Ins.Get<U_OperateTips>().SetData("摆放出界");
                break;
            case EPreviewState.CantBePlaced:
                UI.Ins.Get<U_OperateTips>().SetData("不可摆放到贫瘠土地");
                break;
            case EPreviewState.Colonized:
                UI.Ins.Get<U_OperateTips>().SetData("摆放位置已被入侵");
                break;
        }
        ClearPreview();
    }
    public void UpdatePlace(int towerId)
    {
        ClearPreview();
        List<Grid> grids = new List<Grid>();
        TowerData data = Configs.Ins.GetTower(towerId);
        Vector2Int crd = map.Pos2crd(mousePos);
        Debug.Log(crd);
        Grid centerGrid = map.GetGrid(crd);
        if (!centerGrid)
            return;
        data.Links.ForEach(e =>
        {
            Grid grid = map.GetGrid(map.Pos2crd(mousePos) + e);
            if (!e.Equals(Vector2Int.zero))
            {
                grids.Add(grid);
            }
        });
        if (centerGrid)
        {
            centerGrid.PreviewPlace(towerId);
        }
        grids.ForEach(e =>
        {
            if (e && (e.isColonized || e.tower != null))
            {
                e.PreviewErrorOccupy();
            }
            previewGrids.Add(e);
        });
        previewGrids.Add(centerGrid);

    }
    private void ClearPreview()
    {
        previewGrids.ForEach(e => e?.PreviewCancel());
        previewGrids.Clear();

    }
    private EPreviewState PreviewByMouse(int towerId)
    {
        Grid targetGrid = map.GetGridByPos(mousePos);
        if (!targetGrid)
        {
            return EPreviewState.OutOfEdge;
        }
        else if (!targetGrid.isFertile)
        {
            return EPreviewState.CantBePlaced;
        }
        else if (targetGrid.isColonized)
        {
            return EPreviewState.Colonized;
        }
        else
        {
            Vector2Int targetCrd = targetGrid.crd;
            TowerData data = Configs.Ins.GetTower(towerId);
            List<Vector2Int> crdList = data.Links;
            for (int i = 0; i < crdList.Count; i++)
            {
                Grid grid = map.GetGrid(targetCrd + crdList[i]);
                if (!grid)
                {
                    return EPreviewState.OutOfEdge;
                }
                else if (grid.tower != null)
                {
                    return EPreviewState.Occupied;
                }

            }
        }
        return EPreviewState.Access;

    }
}
