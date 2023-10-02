using System.Collections;
using System.Collections.Generic;
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
    private TowerInfo _tower = null;
    public TowerInfo tower
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
    public void Init(bool isFertile)
    {
        this.isFertile = isFertile;
        gridSprite.sprite = isFertile ? Res.Ins.fertileGridSprite : Res.Ins.poorGridSprite;
    }
    public void Occupied(TowerInfo info)
    {
        this.tower = info;
    }
    public void CancelOccupied()
    {
        this.tower = null;
    }

}
