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
    public TowerBase towerBase;
    public Sprite towerIcon;
    public int cost;
    [SerializeField] List<TowerBase> towers;
    //TODO�����������������ԣ���Ӳ�г������ǹ�һ��

    [Header("Func")]
    public GameObject towerPrefab;
    public TowerSlot[] towerSlots;
    //public Transform towerHolderTransform; //TODO:�϶�
    public TowerManager towerManager;

    //�����֮������������һ�����UI��壬Ȼ��������slot��slot������������Prefab����Prefab���������ͼ�ꡢ���ú����ԡ�
    void Start()
    {
        foreach (var tower in towers)
        {
            AddTowers(tower);
            Debug.Log($"{tower.name} Added Successfully!");
        }

    }
    //��slot��ʼ����ѡ�˽���
    public void AddTowers(TowerBase towerBase)
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

        ////��ʼ�����ĳ�ʼ��Ϣ
        //towerIcon = towerBase.TowerIcon;
        //cost = towerBase.Cost;

        ////update UI
        //towerIconDisp.sprite = towerIcon;
        //towerCostDisp.text = "" + cost;
    }
    //��slot������һ����Prefab
    public void SpawnNewTower(TowerBase tower,TowerSlot slot)
    {
        GameObject newTowerGO = Instantiate(towerPrefab, slot.transform);
        TowerInSlot towerInSlot = newTowerGO.GetComponent<TowerInSlot>();
        towerInSlot.InitialiseTower(tower, towerManager);
    }
    void Update()
    {
        
    }
}
