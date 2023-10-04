using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerDragArea : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public TowerSlot slot;
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (!U_TowerSlotGrp.dragMode)
            return;
        slot.grp.SelectSlot(slot);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!U_TowerSlotGrp.dragMode)
            return;
        // OperateCtrl.Ins.UpdatePlace(slot.towerId);

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (!U_TowerSlotGrp.dragMode)
            return;
        slot.grp.ApplySelect();

    }
}
