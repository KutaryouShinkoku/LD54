using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/Projectile", fileName = "new Projectile")]
public class ProjectileData : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private Sprite sprite;
    [SerializeField] private RuntimeAnimatorController animation;
    public int Id => id;
    public Sprite SpriteIcon => sprite;
    public RuntimeAnimatorController Animation => animation;
}
