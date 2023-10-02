using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerDragArea : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public TowerSlot slot;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        OperateCtrl.Ins.EnterPlace(slot.towerId);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        OperateCtrl.Ins.UpdatePlace(slot.towerId);

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        OperateCtrl.Ins.ExitPlace(slot.towerId);

    }
}
