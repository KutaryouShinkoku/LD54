using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Tower", fileName = "New Tower")]

public class TowerData : ScriptableObject
{
    //基本数据
    [SerializeField] int id;
    [SerializeField] Sprite towerIcon;
    [SerializeField] Sprite slotIcon;
    [SerializeField] Sprite slotIcon2;
    [SerializeField] AttackType attackType; //攻击类型（对地对空）
    [SerializeField] List<Vector2Int> links;
    [SerializeField] int projectileId; //子弹图片
    [SerializeField] Color lvBgColor; //等级背景色
    [SerializeField] RuntimeAnimatorController animator;

    //TODO:[SerializeField] 占地面积
    //TODO:[SerializeField] float cooldown //冷却时间，备用

    //-----------------------------使属性可读-----------------------------
    public Sprite TowerIcon => towerIcon;

    public AttackType AttackType => attackType;

    public int Id => id;

    public List<Vector2Int> Links => links;

    public int ProjectileId => projectileId;

    public RuntimeAnimatorController Animator => animator;

    public Sprite SlotIcon => slotIcon;
    public Sprite SlotIcon2 => slotIcon2;
    public Color LvBgColor => lvBgColor;



}

//攻击类型（对地，对空，都能打）
public enum AttackType { Ground, Air, All }