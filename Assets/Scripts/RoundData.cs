using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "RoundData", fileName = "new RoundData")]
public class RoundData : ScriptableObject
{
    [SerializeField] private int _round;
    [SerializeField] private int _minCreateTime;
    [SerializeField] private int _maxCreateTime;
    [SerializeField] private int enemyCnt;
    /// <summary>
    /// 本轮基础等级
    /// </summary>
    [SerializeField] private int _baseLevel = 1;
    /// <summary>
    /// 刷出baseLevel敌人的权重
    /// </summary>
    [SerializeField] private float _lv1;
    /// <summary>
    /// 刷出baseLevel+1敌人的权重
    /// </summary>
    [SerializeField] private float _lv2;
    /// <summary>
    /// 刷出baseLevel+2敌人的权重
    /// </summary>
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
    public int EnemyCnt
    {
        get { return enemyCnt; }
    }
    public int BaseLevel
    {
        get { return _baseLevel; }
    }
}

