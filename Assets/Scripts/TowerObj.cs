using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerObj : MonoBehaviour
{
    public int towerId = 0;
    public TowerData data => Configs.Ins.GetTower(towerId);
    public int level => GameManager.Ins.GetTowerLevel(towerId);
    public int hp = 100;
    public Vector2Int centerCrd;//攻击锚点坐标
    public PathInfo path => MapCtrl.Ins.GetPathByCrd(centerCrd);
    private float atkTimer = 0;
    public void Init(int towerId, Vector2Int centerCrd)
    {
        this.towerId = towerId;
        this.centerCrd = centerCrd;
        transform.position = Vector3.zero;
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
        Enemy frontEnemy = path.GetFrontEnemy(data.AttackType);
        if (frontEnemy)
        {

        }
    }
    public void OnPathInfoChanged()
    {

    }
}
