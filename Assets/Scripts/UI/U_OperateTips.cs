using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class U_OperateTips : UINode
{
    public GameObject root;
    public Text tips;
    private Animator animator => GetComponent<Animator>();
    public void SetData(string text)
    {
        tips.text = text;
        animator.Play("enter");
    }
}
