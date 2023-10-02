﻿using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    private AttackType enemyType;
    public float hp;
    public Transform hitPos;
    public Animator hurtEffect;
    private bool isDead = false;
    public EnemyData data => Configs.Ins.GetEnemy(enemyType);
    private Animator animator => GetComponent<Animator>();
    private PathInfo pathInfo => MapCtrl.Ins.GetPathById(crd.y);
    private int level = 0;
    public void Init(AttackType type, Vector2Int crd, int level)
    {
        this.enemyType = type;
        this.crd = crd;
        this.hp = 100;
        isDead = false;
        progress = 0;
        this.level = level;
        animator.runtimeAnimatorController = data.Animator;
    }
    /// <summary>
    /// 敌人当前所属格子
    /// </summary>
    public Vector2Int crd;
    /// <summary>
    /// 敌人前往下一个格子的行进进度
    /// </summary>
    public float progress;
    private MapCtrl map => MapCtrl.Ins;
    public Vector2 pos => Vector2.Lerp(map.Crd2Pos(crd), map.Crd2Pos(crd + Vector2Int.left), progress);
    void Update()
    {
        if (isDead)
            return;
        if (pathInfo.frontTower != null && crd.x - 1 == pathInfo.frontTower.centerCrd.x)
        {
            animator.SetBool("isAtking", true);
        }
        else
        {
            animator.SetBool("isAtking", false);
            progress += Time.deltaTime * Configs.Ins.enemySpeed;
            if (progress >= 1)
            {
                progress = 0;
                crd += Vector2Int.left;
                pathInfo.OnEnemyMoveNext();
            }

        }
        transform.position = pos;
        if (pos.x < map.maxLeft)
        {
            GameManager.Ins.Lose();
        }
    }
    public void OnPathInfoChanged()
    {
        if (pathInfo.frontTower != null && crd.x - 1 == pathInfo.frontTower.centerCrd.x)
        {
            animator.SetBool("isAtking", true);
        }

    }
    public void Hurt()
    {
        hurtEffect.Play("EnemyHurtEffect");
        hp -= Configs.Ins.towerDamage;
        if (hp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        animator.SetTrigger("die");
        MapCtrl.Ins.KillEnemy(this);
    }
    public void Clear()
    {
        gameObject.OPPush();
    }
    public void Attack()
    {
        pathInfo.frontTower?.Hurt();
    }
}

