using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnDelete : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        OperateCtrl.Ins.EnterDelete();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        OperateCtrl.Ins.UpdateDelete();

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        OperateCtrl.Ins.ExitDelete();

    }
}
