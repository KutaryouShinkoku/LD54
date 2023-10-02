using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy", fileName = "Add New Tower")]
public class EnemyData : ScriptableObject
{

    [SerializeField] private int _hp;
    [SerializeField] private int _attack;
    [SerializeField] private EEnemyType _enemyType;
    [SerializeField] private float _speed;
    [SerializeField] private int _level;

    public int hp
    {
        get { return _hp; }
    }
    public int attack
    {
        get { return _attack; }
    }
    public EEnemyType enemyType
    {
        get { return _enemyType; }
    }
    public float speed
    {
        get { return _speed; }
    }
    public int level
    {
        get { return _level; }
    }


}
public enum EEnemyType { enemy };
