using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "EnemyCreator", fileName = "Add New EnemyCreator")]
public class EnemyCreatorData : ScriptableObject
{
    [SerializeField] private int _round;
    [SerializeField] private int _minCreateTime;
    [SerializeField] private int _maxCreateTime;
    //敌人等级占比
    [SerializeField] private float _lv1;
    [SerializeField] private float _lv2;
    [SerializeField] private float _lv3;

    public float lv1
    {
        get { return _lv1; }
    }
    public float lv2
    {
        get { return _lv2; }
    }
    public float lv3
    {
        get { return _lv3; }
    }
    public int round
    {
        get { return _round; }
    }
    public int minCreateTime
    {
        get { return _minCreateTime; }
    }
    public int maxCreateTime
    {
        get { return _maxCreateTime; }
    }
}

