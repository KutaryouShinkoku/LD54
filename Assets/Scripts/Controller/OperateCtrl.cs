using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EPreviewState
{
    Access,
    Occupied,
    OutOfEdge,
}
public class OperateCtrl : Singleton<OperateCtrl>
{
    private MapCtrl map => MapCtrl.Ins;
    public Transform targetImg;
    public Vector2 mousePos => Camera.main.ScreenToWorldPoint(Input.mousePosition);
    public void EnterPlace(int towerId)
    {

    }
    public void ExitPlace(int towerId)
    {
        Grid targetGrid = map.GetGridByPos(mousePos);
        if (!targetGrid)
        {
            UI.Ins.Get<U_OperateTips>().SetData("不可摆放到空地格");
        }
        else if (!targetGrid.isFertile)
        {
            UI.Ins.Get<U_OperateTips>().SetData("不可摆放到贫瘠土地");
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
                    UI.Ins.Get<U_OperateTips>().SetData("摆放出界");
                }
                else if (grid.tower != null)
                {
                    UI.Ins.Get<U_OperateTips>().SetData("摆放位置已被占用");
                }
                else
                {
                    map.PlaceTower(towerId, targetCrd);
                }
            }
        }
    }
    public void UpdatePlace(int towerId)
    {

    }
}
