using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerObj : MonoBehaviour
{
    public TowerInfo info;
    public Vector2Int centerCrd;//攻击锚点坐标
    public PathInfo path => MapCtrl.Ins.GetPathByCrd(centerCrd);
    private float atkTimer = 0;
    public void Init(TowerInfo info, Vector2Int centerCrd)
    {
        this.info = info;
        this.centerCrd = centerCrd;
    }
    public void Clear()
    {
        this.gameObject.OPPush();
    }
    private void Update()
    {

    }
    private void Attack()
    {
        Enemy frontEnemy = path.GetFrontEnemy(info.data.AttackType);
        if (frontEnemy)
        {

        }
    }
    public void OnPathInfoChanged()
    {

    }
}
