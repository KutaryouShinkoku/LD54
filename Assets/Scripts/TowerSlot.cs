using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//拖拽防御塔的交互
public class TowerSlot : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private int _towerId;
    public int towerId => this._towerId;
    private Sprite selectSprite => Configs.Ins.GetTower(towerId).SlotIcon2;
    private Sprite normalSprite => Configs.Ins.GetTower(towerId).SlotIcon;
    [SerializeField] Image icon;
    [SerializeField] Text cost;
    private TowerSlotGrp _grp;
    public TowerSlotGrp grp => _grp;


    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (!TowerSlotGrp.dragMode)
            return;
        grp.SelectSlot(this);
        Debug.Log("drag");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (!TowerSlotGrp.dragMode)
            return;
        // OperateCtrl.Ins.UpdatePlace(slot.towerId);

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (!TowerSlotGrp.dragMode)
            return;
        grp.ApplySelect();

    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (TowerSlotGrp.dragMode)
            return;
        _grp.SelectSlot(this);
        ScreenTouch.Ins.SetData(() =>
        {
            if (TowerSlotGrp.dragMode)
                return;
            _grp.ApplySelect();
        });
        Debug.Log("down");
    }
    private void Update()
    {
        cost.text = "" + GameManager.Ins.GetTowerCost(towerId);
    }
    public void OnSelect()
    {
        icon.sprite = selectSprite;
    }
    public void OnCancelSelect()
    {
        icon.sprite = normalSprite;
    }
    public void Init(TowerSlotGrp grp)
    {
        icon.sprite = normalSprite;
        this._grp = grp;
    }
}
