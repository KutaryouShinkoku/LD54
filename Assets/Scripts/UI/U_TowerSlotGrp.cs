using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U_TowerSlotGrp : UINode
{
    public static bool dragMode;
    [SerializeField] List<TowerSlot> towerSlots;
    [SerializeField] Text _energyCount;
    private TowerSlot operatingSlot = null;
    private bool isInDelete = false;
    protected override void Start()
    {
        base.Start();
        towerSlots.ForEach(e => e.Init(this));
    }
    public void DeleteSlot()
    {
        isInDelete = true;
        OperateCtrl.Ins.EnterDelete();
    }
    public void ApplyDelete()
    {
        if (!isInDelete)
            return;
        OperateCtrl.Ins.ExitDelete();
        isInDelete = false;
    }
    public void SelectSlot(TowerSlot slot)
    {
        towerSlots.ForEach(e =>
        {
            if (e == slot)
                e.OnSelect();
            else
                e.OnCancelSelect();
        });
        OperateCtrl.Ins.EnterPlace(slot.towerId);
        operatingSlot = slot;
    }
    public void ApplySelect()
    {
        if (!operatingSlot)
            return;
        OperateCtrl.Ins.ExitPlace(operatingSlot.towerId);
        operatingSlot.OnCancelSelect();
        operatingSlot = null;

    }
    public void SparkleSlotPrice(int towerId)
    {
        TowerSlot slot = towerSlots.Find(e => e.towerId == towerId);
        slot.SparklePrice();
    }
    private void Update()
    {
        _energyCount.text = "" + GameManager.Ins.energy;
        if (operatingSlot && !isInDelete)
        {
            OperateCtrl.Ins.UpdatePlace(operatingSlot.towerId);
        }
        else if (isInDelete)
        {
            OperateCtrl.Ins.UpdateDelete();
        }
    }
}
