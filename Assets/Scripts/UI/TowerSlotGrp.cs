using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSlotGrp : MonoBehaviour
{
    public static bool dragMode;
    [SerializeField] List<TowerSlot> towerSlots;
    [SerializeField] Text _energyCount;
    private TowerSlot operatingSlot = null;
    private void Start()
    {
        towerSlots.ForEach(e => e.Init(this));
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
    private void Update()
    {
        _energyCount.text = "" + GameManager.Ins.energy;
        if (operatingSlot)
        {
            OperateCtrl.Ins.UpdatePlace(operatingSlot.towerId);
        }
    }
}
