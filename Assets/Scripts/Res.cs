using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Res : Singleton<Res>
{
    [Header("预制体")]
    public GameObject gridPrefab;
    [Header("图片")]
    public Sprite fertileGridSprite;
    public Sprite poorGridSprite;
}
