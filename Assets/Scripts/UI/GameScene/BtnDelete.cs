using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnDelete : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    [SerializeField] private U_TowerSlotGrp slotGrp;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (U_TowerSlotGrp.dragMode)
            return;
        slotGrp.DeleteSlot();
        ScreenTouch.Ins.SetData(() =>
        {
            if (U_TowerSlotGrp.dragMode)
                return;
            slotGrp.ApplyDelete();
        });
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (!U_TowerSlotGrp.dragMode)
            return;
        slotGrp.DeleteSlot();

    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!U_TowerSlotGrp.dragMode)
            return;
        // OperateCtrl.Ins.UpdateDelete();

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (!U_TowerSlotGrp.dragMode)
            return;
        slotGrp.ApplyDelete();


    }
}
