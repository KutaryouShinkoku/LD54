using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public bool isFertile = false;
    public Vector2Int crd;
    public void Init(bool isFertile)
    {
        this.isFertile = isFertile;
        gridSprite.sprite = isFertile ? Res.Ins.fertileGridSprite : Res.Ins.poorGridSprite;
    }
    private SpriteRenderer gridSprite => transform.Find("gridSprite").GetComponent<SpriteRenderer>();
    private SpriteRenderer preview => transform.Find("preview").GetComponent<SpriteRenderer>();
}
