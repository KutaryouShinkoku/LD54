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
    private bool isInAtking = false;
    private Animator animator => GetComponent<Animator>();
    public void Init(int towerId, Vector2Int centerCrd)
    {
        this.towerId = towerId;
        this.centerCrd = centerCrd;
        transform.localPosition = Vector3.zero;
        animator.runtimeAnimatorController = data.Animator;
    }
    public void Clear()
    {
        gameObject.OPPush();
    }
    private void Update()
    {
        if (isInAtking)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer >= Configs.Ins.towerAtkInterval)
            {
                atkTimer = 0;
                Attack();
            }
        }
        else
        {
            atkTimer = 0;
        }
    }
    private void Attack()
    {
        Enemy frontEnemy = path.GetFrontEnemy(data.AttackType);
        if (frontEnemy)
        {
            Projectile projectile = Res.Ins.projectilePrefab.OPGet().GetComponent<Projectile>();
            projectile.transform.SetParent(MapCtrl.Ins.projectileFolder);
            projectile.transform.position = transform.position;
            projectile.Init(path.pathId);
        }
    }
    public void OnPathInfoChanged()
    {
        isInAtking = path.GetFrontEnemy(data.AttackType) != null;
    }
}
