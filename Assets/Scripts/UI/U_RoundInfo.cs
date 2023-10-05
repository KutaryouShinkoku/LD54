using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U_RoundInfo : UINode
{
    public Text enemyCnt;
    public Text roundCnt;
    public Animator animator;
    private bool updateInfo = false;
    private void Update()
    {
        if (updateInfo)
        {
            enemyCnt.text = $"{GameManager.Ins.enemyCreator.EnemyRemain}";
            roundCnt.text = $"{GameManager.Ins.round}";
        }
    }
    public void Enter()
    {
        animator.Play("Enter");
        updateInfo = true;
    }
    public void Exit()
    {
        animator.Play("Exit");
        updateInfo = false;
    }
}
