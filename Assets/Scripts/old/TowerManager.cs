using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    [Header("UI")]
    public Image towerIconDisp;
    public Text towerCostDisp;

    [Header("Tower")]
    public TowerData towerBase;
    public Sprite towerIcon;
    public int cost;
    [SerializeField] List<TowerData> towers;
    //TODO：其它可升级的属性，是硬列出来还是归一类

    [Header("Func")]
    public GameObject towerPrefab;
    public TowerSlot[] towerSlots;
    //public Transform towerHolderTransform; //TODO:拖动
    public TowerManager towerManager;

    //简而言之，我是先做了一个大的UI面板，然后里面做slot，slot里面生成塔的Prefab，塔Prefab里包含塔的图标、费用和属性。
    void Start()
    {
        foreach (var tower in towers)
        {
            AddTowers(tower);
            Debug.Log($"{tower.name} Added Successfully!");
        }

    }
    //把slot初始化到选人界面
    public void AddTowers(TowerData towerBase)
    {
        for(int i = 0; i < towerSlots.Length; i++)
        {
            TowerSlot slot = towerSlots[i];
            TowerInSlot towerInSlot = slot.GetComponentInChildren<TowerInSlot>();
            if(towerInSlot == null)
            {
                SpawnNewTower(towerBase, slot);
                return;
            }
        }

        ////初始化塔的初始信息
        //towerIcon = towerBase.TowerIcon;
        //cost = towerBase.Cost;

        ////update UI
        //towerIconDisp.sprite = towerIcon;
        //towerCostDisp.text = "" + cost;
    }
    //在slot里生成一个塔Prefab
    public void SpawnNewTower(TowerData tower,TowerSlot slot)
    {
        GameObject newTowerGO = Instantiate(towerPrefab, slot.transform);
        TowerInSlot towerInSlot = newTowerGO.GetComponent<TowerInSlot>();
        towerInSlot.InitialiseTower(tower, towerManager);
    }
    void Update()
    {
        
    }
}
