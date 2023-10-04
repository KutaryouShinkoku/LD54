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
    private U_TowerSlotGrp _grp;
    public U_TowerSlotGrp grp => _grp;
    [SerializeField] private Image mask;


    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (!U_TowerSlotGrp.dragMode)
            return;
        grp.SelectSlot(this);
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
        grp.ApplySelect();

    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (U_TowerSlotGrp.dragMode)
            return;
        _grp.SelectSlot(this);
        ScreenTouch.Ins.SetData(() =>
        {
            if (U_TowerSlotGrp.dragMode)
                return;
            _grp.ApplySelect();
        });
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
    public void Init(U_TowerSlotGrp grp)
    {
        icon.sprite = normalSprite;
        this._grp = grp;
    }
    public void SparklePrice()
    {
        Color maskColor = mask.color;
        TM.SetTimer(this.Hash("SparkPrice"), 0.5f, p =>
        {
            mask.color = new Color(maskColor.r, maskColor.g, maskColor.b, Mathf.Lerp(1, 0, p));
        });
    }
}
