using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//拖拽防御塔的交互
public class TowerSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public int towerId;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        OperateCtrl.Ins.EnterPlace(towerId);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        OperateCtrl.Ins.UpdatePlace(towerId);

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        OperateCtrl.Ins.ExitPlace(towerId);

    }
}
