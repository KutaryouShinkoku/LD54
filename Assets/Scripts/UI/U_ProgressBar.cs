using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U_ProgressBar : UINode
{
    public Image bar;
    public Animator animator;
    public Text text;
    public void Enter(string msg)
    {
        animator.Play("Enter");
        text.text = msg;
    }
    public void Exit()
    {
        animator.Play("Exit");
    }
    public void UpdateProgress(float p)
    {
        bar.fillAmount = p;
    }
}
