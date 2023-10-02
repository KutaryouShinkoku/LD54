using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AttackType type;
    public int pathId;
    public PathInfo path => MapCtrl.Ins.GetPathById(pathId);
    public SpriteRenderer render;
    public void Init(int pathId, Sprite sprite, AttackType type)
    {
        this.pathId = pathId;
        render.sprite = sprite;
        this.type = type;
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
