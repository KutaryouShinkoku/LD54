using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower", fileName = "Add New Tower")]

public class TowerData : ScriptableObject
{
    //基本数据
    [SerializeField] int id;
    [SerializeField] Sprite towerIcon;
    [SerializeField] AttackType attackType; //攻击类型（对地对空）
    [SerializeField] List<Vector2Int> links;
    [SerializeField] Sprite projectileSprite; //子弹图片

    //TODO:[SerializeField] 占地面积
    //TODO:[SerializeField] float cooldown //冷却时间，备用

    //-----------------------------使属性可读-----------------------------
    public Sprite TowerIcon
    {
        get { return towerIcon; }
    }
    public AttackType AttackType
    {
        get { return attackType; }
    }
    public int Id
    {
        get { return id; }
    }
    public List<Vector2Int> Links
    {
        get { return links; }
    }
    public Sprite ProjectileSprite
    {
        get { return projectileSprite; }
    }

}

//攻击类型（对地，对空，都能打）
public enum AttackType { Ground, Air, All }