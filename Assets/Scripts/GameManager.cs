using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private bool isOver = false;
    public int round = 1;
    public int energy = 0;
    private float waveTimer = 0;
    private bool isInPrepare = false;
    public RoundData roundData => Configs.Ins.GetEnemyCreatorData(round);
    public EnemyCreator enemyCreator;
    public ETowerSlotType towerSlotType;
    public Animator progressAnimator;
    public Image progressBar;
    public Text roundText;
    public GameObject _uiWin;
    public GameObject _uiLose;
    public int GetTowerCost(int towerId)
    {
        int num = MapCtrl.Ins.GetTowerNumById(towerId);
        return Configs.Ins.baseTowerCost + num * Configs.Ins.addTowerCost;
    }

    public void AddEnergy(int energy)
    {
        this.energy += energy;
        // EC.Send(EC.UPDATE_ENERGY);
    }

    private void Start()
    {
        ResetGameUI();
        InitGame();
    }

    public void InitGame()
    {
        round = 1;
        energy = 0;
        isOver = false;
        StartWave();
        towerSlotType = ETowerSlotType.buy;
        MapCtrl.Ins.InitMap();
    }

    /// <summary>
    /// 结束进攻波次
    /// </summary>
    public void FinishWave()
    {
        if (isOver)
            return;
        round++;
        if (round > 3)
        {
            Win();
            return;
        }
        StartWave();
    }

    private void StartWave()
    {
        waveTimer = 0;
        isInPrepare = true;
        progressAnimator.Play("Enter");
        roundText.text = "Round" + round + " are coming!";
    }

    private void Update()
    {
        if (!isInPrepare)
            return;
        if (waveTimer >= roundData.PrepareTime)
        {
            enemyCreator.StartCreate();
            progressAnimator.Play("Exit");
            isInPrepare = false;
        }
        progressBar.fillAmount = waveTimer / roundData.PrepareTime;
        waveTimer += Time.deltaTime;

        //按R重开
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void ResetGameUI()
    {
        _uiWin.SetActive(false);
        _uiLose.SetActive(false);
    }
    public void Win()
    {
        _uiWin.SetActive(true);
        isOver = true;
    }

    public void Lose()
    {
        _uiLose.SetActive(true);
        isOver = true;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    //重开
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
