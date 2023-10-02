using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AttackType type;
    public int pathId;
    public PathInfo info => MapCtrl.Ins.GetPathById(pathId);
    public void Init(int pathId)
    {
        this.pathId = pathId;
    }
}
