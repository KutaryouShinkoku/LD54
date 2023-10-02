using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy", fileName = "Add New Tower")]
public class EnemyData : ScriptableObject
{

    [SerializeField] private List<int> _attack;
    [SerializeField] private AttackType _enemyType;
    [SerializeField] private List<float> _speed;
    [SerializeField] private int _level;
    [SerializeField] private RuntimeAnimatorController animator;


    public int attack => _attack[level];

    public AttackType enemyType => _enemyType;

    public float speed => _speed[level];

    public int level => _level;
    public RuntimeAnimatorController Animator => animator;



}
