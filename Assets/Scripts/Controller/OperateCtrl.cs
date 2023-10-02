using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            TowerData data = Configs.Ins.GetTower(towerId);
            List<Vector2Int> crdList = data.Links;
            // for (int i = 0; i < crdList.Count; i++)
            // {
            //     Grid grid = GetGrid(targetCrd + crdList[i]);
            //     if (!grid)
            //         return false;
            //     else if (grid.isOccupy)
            //         return false;
            // }
        }

    }
    public void UpdatePlace(int towerId)
    {
    }
}
