using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower", fileName = "Add New Tower")]

public class TowerData : ScriptableObject
{
    //基本数据
    [SerializeField] int id;
    [SerializeField] Sprite towerIcon;
    [SerializeField] int cost;
    //可升级数据
    [SerializeField] int attack; //单发伤害
    [SerializeField] float attackInterval; //攻击间隔（秒）
    [SerializeField] AttackType attackType; //攻击类型（对地对空）
    [SerializeField] int hp; //血量
    [SerializeField] List<Vector2Int> links;

    //TODO:[SerializeField] 占地面积
    //TODO:[SerializeField] float cooldown //冷却时间，备用

    //-----------------------------使属性可读-----------------------------
    public Sprite TowerIcon
    {
        get { return towerIcon; }
    }
    public int Cost
    {
        get { return cost; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public float AttackInterval
    {
        get { return attackInterval; }
    }
    public AttackType AttackType
    {
        get { return attackType; }
    }

    public int Hp
    {
        get { return hp; }
    }
    public int Id
    {
        get { return id; }
    }
    public List<Vector2Int> Links
    {
        get { return links; }
    }

}

//攻击类型（对地，对空，都能打）
public enum AttackType { Ground, Air, All }