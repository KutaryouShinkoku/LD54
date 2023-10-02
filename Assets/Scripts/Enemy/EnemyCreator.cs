using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{

    [SerializeField]
    public Transform _creatorRoot;
    public int _round;
    public EnemyCreatorData _enemyCreatorData;
    // Use this for initialization
    void Start()
    {
        _round = GameManager.Ins.round;
        _enemyCreatorData = GameManager.Ins._enemyCreatorData;
        time = Random.Range(_enemyCreatorData.minCreateTime, _enemyCreatorData.maxCreateTime);
    }
    //秒
    private bool _isCreated = false;
    // Update is called once per frame
    private float time;
    void Update()
    {
        initCreatorData();

        if (time < 0)
        {

            //生成敌人 
            GameObject enemy = Res.Ins.enemyPrefab.OPGet();
            enemy.transform.SetParent(_creatorRoot);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            //enemyScript.onInit(Configs.Ins.getEnemy();
            _isCreated = true;
            time = Random.Range(_enemyCreatorData.minCreateTime, _enemyCreatorData.maxCreateTime);
        }
        else
        {
            time -= Time.deltaTime; 
        }

    }
    private void initCreatorData()
    {
        if (_round == GameManager.Ins.round)
        {
            return;
        }
        _round = GameManager.Ins.round;
        _enemyCreatorData = GameManager.Ins._enemyCreatorData;
    }
}
