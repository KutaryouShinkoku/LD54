using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerObj : MonoBehaviour
{
    public int towerId = 0;
    public TowerData data => Configs.Ins.GetTower(towerId);
    public int level => GameManager.Ins.GetTowerLevel(towerId);
    public float hp = 100;
    public Vector2Int centerCrd;//攻击锚点坐标
    public Transform atkPos;
    public PathInfo path => MapCtrl.Ins.GetPathByCrd(centerCrd);
    private float atkTimer = 0;
    private bool isInAtking = false;
    private Animator animator => GetComponent<Animator>();
    public void Init(int towerId, Vector2Int centerCrd)
    {
        this.towerId = towerId;
        hp = 100;
        this.centerCrd = centerCrd;
        transform.localPosition = Vector3.zero;
        animator.runtimeAnimatorController = data.Animator;
    }
    private void Update()
    {
        if (isInAtking)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer >= Configs.Ins.towerAtkInterval)
            {
                atkTimer = 0;
                animator.SetBool("isAtking", true);
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
            projectile.transform.position = atkPos.position;
            projectile.Init(path.pathId, data.ProjectileSprite, data.AttackType);
        }
    }
    public void Hurt()
    {
        hp -= Configs.Ins.enemyDamage;
        if (hp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        MapCtrl.Ins.DestoryTower(this);
        animator.SetTrigger("die");
    }
    public void Clear()
    {

        gameObject.OPPush();
    }
    public void OnPathInfoChanged()
    {
        isInAtking = path.GetFrontEnemy(data.AttackType) != null;
        animator.SetBool("isAtking", isInAtking);
    }
}
