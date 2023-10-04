using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AttackType type;
    public int pathId;
    public PathInfo path => MapCtrl.Ins.GetPathById(pathId);
    private int id;
    public SpriteRenderer render;
    public Animator animator;
    public ProjectileData data => Configs.Ins.GetProjectileData(id);
    public void Init(int pathId, int id, AttackType type)
    {
        this.pathId = pathId;
        this.id = id;
        this.type = type;
        render.sprite = data.SpriteIcon;
        animator.runtimeAnimatorController = data.Animation;
    }
    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * Configs.Ins.projectileSpeed;
        Enemy enemy = path.GetFrontEnemy(type);
        if (enemy != null && transform.position.x >= enemy.hitPos.position.x)
        {
            if (enemy)
            {
                enemy.Hurt();
            }
            gameObject.OPPush();
        }
    }
}
