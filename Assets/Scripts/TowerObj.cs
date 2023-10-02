using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerObj : MonoBehaviour
{
    public TowerInfo info;
    public Vector2Int centerCrd;//攻击锚点坐标
    public void Init(TowerInfo info, Vector2Int centerCrd)
    {
        this.info = info;
        this.centerCrd = centerCrd;
    }
    public void Clear()
    {
        this.gameObject.OPPush();
    }
}
