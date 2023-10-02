using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AttackType type;
    public int pathId;
    public PathInfo path => MapCtrl.Ins.GetPathById(pathId);
    public SpriteRenderer render;
    public void Init(int pathId)
    {
        this.pathId = pathId;
    }
    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * Configs.Ins.projectileSpeed;
        float targetX = path.frontLine;
        Enemy enemy = path.GetFrontEnemy(type);
        if (transform.position.x >= targetX && enemy != null)
        {
            if (enemy)
            {
                enemy.Attacked();
            }
            gameObject.OPPush();
        }
    }
}
