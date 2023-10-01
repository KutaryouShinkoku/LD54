using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower", fileName = "Add New Tower")]

public class TowerData : ScriptableObject
{
    //��������
    [SerializeField] int id;
    [SerializeField] Sprite towerIcon;
    [SerializeField] int cost;
    //����������
    [SerializeField] int attack; //�����ӵ�������
    [SerializeField] float attackInterval; //���������ʱ�䣩
    [SerializeField] TowerAttackType attackType; //�������ͣ��Եػ��ǶԿգ�
    [SerializeField] int hp; //Ѫ��
    [SerializeField] List<Vector2Int> links;

    //TODO:[SerializeField] ��ռ��������״�ȹ���
    //TODO:[SerializeField] float cooldown //�²߻�����ȴʱ�书�ܣ���һ��������

    //-----------------------------ʹ���Կɶ�-----------------------------
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
    public TowerAttackType AttackType
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

//�������Ĺ�����Χ���Եء��Կա����ܴ�
public enum TowerAttackType { Ground, Air, All }