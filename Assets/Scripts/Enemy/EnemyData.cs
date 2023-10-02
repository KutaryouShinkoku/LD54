using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy", fileName = "Add New Tower")]
public class EnemyData : ScriptableObject
{

    [SerializeField] private List<int> _attack;
    [SerializeField] private AttackType _enemyType;
    [SerializeField] private float _speed;
    [SerializeField] private int _level;
    [SerializeField] private RuntimeAnimatorController animator;
    [SerializeField] private List<int> _hp;


    public List<int> attack => _attack;

    public AttackType enemyType => _enemyType;

    public float speed => _speed;
    public List<int> hp => _hp;
    public int level => _level;
    public RuntimeAnimatorController Animator => animator;



}
