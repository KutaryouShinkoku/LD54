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

    public int round => _round;

    public float minCreateTime => _minCreateTime;

    public float maxCreateTime => _maxCreateTime;

    public int EnemyCnt => enemyCnt;


    public float PrepareTime => _prepareTime;

}

