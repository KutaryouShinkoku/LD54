using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{

    [SerializeField]
    public Transform _creatorRoot;
    // Use this for initialization
    void Start()
    {

    }

    private bool _isCreated = false;
    // Update is called once per frame
    void Update()
    {
        if (!_isCreated)
        {
            //生成敌人 
            GameObject enemy = Res.Ins.enemyPrefab.OPGet();
            enemy.transform.SetParent(_creatorRoot);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.onInit();
            _isCreated = true;
            
        }
    }
}
