using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int round = 1;
    public int money = 0;
    public void InitGame()
    {
        round = 1;
        money = 0;
    }
}
