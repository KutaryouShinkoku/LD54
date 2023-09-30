using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower",fileName = "Add New Tower")]

public class TowerBase : ScriptableObject
{
    //基础属性
    [SerializeField] Sprite towerIcon;
    [SerializeField] int cost;

    //可升级属性
    [SerializeField] int attack; //单发子弹攻击力
    [SerializeField] float attackInterval; //攻击间隔（时间）
    [SerializeField] TowerAttackType attackType; //攻击类型（对地还是对空）
    [SerializeField] int hp; //血量

    //TODO:[SerializeField] 所占行数、形状等功能
    //TODO:[SerializeField] float cooldown //怕策划加冷却时间功能，放一个在这里

    //-----------------------------使属性可读-----------------------------
    public Sprite TowerIcon{
        get { return towerIcon; }
    }
    public int Cost{
        get { return cost; }
    }

    public int Attack{
        get { return attack; }
    }

    public float AttackInterval{
        get { return attackInterval; }
    }
    public TowerAttackType AttackType{
        get { return attackType; }
    }

    public int Hp{
        get { return hp; }
    }

}

//防御塔的攻击范围：对地、对空、都能打
public enum TowerAttackType { Ground,Air,All}