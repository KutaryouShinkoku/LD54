using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private bool _isFertile = false;
    public bool isFertile
    {
        get => _isFertile;
        set
        {
            _isFertile = value;
        }
    }
    private TowerObj _tower = null;
    public TowerObj tower
    {
        get => _tower;
        set
        {
            _tower = value;
        }
    }
    private bool _isColonized = false;
    public bool isColonized
    {
        get => _isColonized;
        set
        {
            _isColonized = value;
        }
    }
    public Vector2Int crd;
    private SpriteRenderer gridSprite => transform.Find("gridSprite").GetComponent<SpriteRenderer>();
    private SpriteRenderer preview => transform.Find("preview").GetComponent<SpriteRenderer>();
    private SpriteRenderer mask => transform.Find("mask").GetComponent<SpriteRenderer>();
    public Transform towerFolder;
    public void Init(bool isFertile)
    {
        this.isFertile = isFertile;
        gridSprite.sprite = isFertile ? Res.Ins.fertileGridSprite : Res.Ins.poorGridSprite;
    }
    public void Occupied(TowerObj info)
    {
        this.tower = info;
    }
    public void CancelOccupied()
    {
        this.tower = null;
    }


    public void PreviewPlace(int towerId)
    {
        TowerData data = Configs.Ins.GetTower(towerId);
        preview.gameObject.SetActive(true);
        preview.sprite = data.TowerIcon;
    }
    public void PreviewErrorOccupy()
    {
        mask.gameObject.SetActive(true);
    }
    public void PreviewCancel()
    {
        preview.gameObject.SetActive(false);
        mask.gameObject.SetActive(false);
    }

}
