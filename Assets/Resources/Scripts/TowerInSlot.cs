using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInSlot : MonoBehaviour
{
    [HideInInspector] public TowerBase towerBase;

    public Image image;
    public Text cost;
    public GameObject ImgGO;
    public TowerManager towerManager;
    void Start()
    {
        InitialiseTower(towerBase, towerManager);
    }

    public void InitialiseTower(TowerBase newTower, TowerManager manager)
    {
        towerBase = newTower;
        image = ImgGO.GetComponent<Image>();
        image.sprite = newTower.TowerIcon;
        cost.text = "" + newTower.Cost;
        towerManager = manager;
        Debug.Log($"{newTower.name} Initialised Successfully!");
    }

    //TODO£ºÍÏ×§·ÀÓùËþµ½³¡ÉÏ

}
