using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "GameData/Round", fileName = "new RoundData")]
public class RoundData : ScriptableObject
{
    /// <summary>
    /// 准备时间
    /// </summary>
    [SerializeField] private float _prepareTime;
    [SerializeField] private int _round;
    [SerializeField] private float _minCreateTime;
    [SerializeField] private float _maxCreateTime;
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

    public float lv1 => _lv1;

    public float lv2 => _lv2;

    public float lv3 => _lv3;

    public int round => _round;

    public float minCreateTime => _minCreateTime;

    public float maxCreateTime => _maxCreateTime;

    public int EnemyCnt => enemyCnt;

    public int BaseLevel => _baseLevel;

    public float PrepareTime => _prepareTime;

}

