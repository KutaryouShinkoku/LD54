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
    [SerializeField] RuntimeAnimatorController animator;
    [SerializeField] List<int> _attack;//伤害
    [SerializeField] int _level;
    [SerializeField] List<int> _upgradeCost;
    [SerializeField] List<int> _buyCost;

    //TODO:[SerializeField] 占地面积
    //TODO:[SerializeField] float cooldown //冷却时间，备用

    //-----------------------------使属性可读-----------------------------
    public Sprite TowerIcon => towerIcon;

    public AttackType AttackType => attackType;

    public int Id => id;

    public List<Vector2Int> Links => links;

    public Sprite ProjectileSprite => projectileSprite;

    public RuntimeAnimatorController Animator => animator;

    public List<int> attack => _attack;

    public int level => _level;

    public List<int> upgradeCost => _upgradeCost;
    public List<int> buyCost => _buyCost;

}

//攻击类型（对地，对空，都能打）
public enum AttackType { Ground, Air, All }