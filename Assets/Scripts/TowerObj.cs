using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TowerObj : MonoBehaviour
{
    private int _towerId = 0;
    public int towerId => _towerId;
    public TowerData data => Configs.Ins.GetTower(towerId);
    public float hp = 100;
    public float atkSpeed => 1 + lv * Configs.Ins.addTowerAtkSpeed;
    private bool isInPreview = false;
    public Vector2Int centerCrd;//攻击锚点坐标
    public Transform atkPos;
    public PathInfo path => MapCtrl.Ins.GetPathByCrd(centerCrd);
    private List<Grid> buffGrids = new List<Grid>();
    private float atkTimer = 0;
    private bool isInAtking = false;
    private Animator animator => GetComponent<Animator>();
    private AnimatorStateInfo curState => animator.GetCurrentAnimatorStateInfo(0);
    [SerializeField] private Transform lvShow;
    private int _lv = 0;
    public int lv => _lv;
    [SerializeField] private Image lvBg;
    [SerializeField] private Text lvText;
    [SerializeField] private SpriteRenderer sprr;
    private void OnEnable()
    {
        EC.On(EC.CHANGE_PLACE_TOWER, RefreshLv);
    }
    private void OnDisable()
    {
        EC.Off(EC.CHANGE_PLACE_TOWER, RefreshLv);

    }
    public void Init(int towerId, Vector2Int centerCrd)
    {
        buffGrids = new List<Grid>();
        this._towerId = towerId;
        hp = 100;
        _lv = -1;
        this.centerCrd = centerCrd;
        transform.localPosition = Vector3.zero;
        animator.runtimeAnimatorController = data.Animator;
        isInPreview = false;
        RefreshLv();
    }
    private void Update()
    {
        if (isInAtking)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer >= Configs.Ins.towerAtkInterval)
            {
                atkTimer = 0;
                animator.SetBool("isAtking", true);
            }
            animator.speed = atkSpeed;
        }
        else
        {
            animator.speed = 1;
            atkTimer = 0;
        }
    }
    public void RefreshLv()
    {
        int curLv = 0;
        List<Grid> nearGrids = MapCtrl.Ins.GetNearGrid(centerCrd);
        List<Grid> newBuffGrids = new List<Grid>();
        for (int i = 0; i < nearGrids.Count; i++)
        {
            Grid grid = nearGrids[i];
            if (grid.tower != null && grid.tower.data.AttackType == data.AttackType && grid.tower != this)
            {
                curLv++;
                if (!buffGrids.Contains(grid))
                    grid.ShowUnionBuff(data.LvBgColor);
                newBuffGrids.Add(grid);
            }
        }
        buffGrids = newBuffGrids;
        if (_lv != curLv)
        {
            _lv = curLv;
            ShowChangeLv();
        }
    }
    private void ShowChangeLv()
    {
        lvShow.gameObject.SetActive(_lv > 0);
        if (_lv > 0)
        {
            TM.SetTimer(this.Hash("changeLv"), 0.5f, p =>
            {
                lvBg.color = Color.Lerp(Color.white, data.LvBgColor, p);
            });
            lvText.text = $"+{_lv}";
        }
    }
    private void Attack()
    {
        Enemy frontEnemy = path.GetFrontEnemy(data.AttackType);
        if (frontEnemy)
        {
            Projectile projectile = Res.Ins.projectilePrefab.OPGet().GetComponent<Projectile>();
            projectile.transform.SetParent(MapCtrl.Ins.projectileFolder);
            projectile.transform.position = atkPos.position;
            projectile.Init(path.pathId, data.ProjectileId, data.AttackType);
        }
    }
    public void Hurt()
    {
        hp -= Configs.Ins.enemyDamage;
        TM.SetTimer(this.Hash("towerHurt"), 0.3f, p =>
        {
            if (!isInPreview)
                sprr.color = Color.Lerp(Color.red, Color.white, p);
        });
        if (hp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        MapCtrl.Ins.DestoryTower(this);
        animator.SetTrigger("die");
    }
    public void Clear()
    {

        gameObject.OPPush();
    }
    public void OnPathInfoChanged()
    {
        isInAtking = path.GetFrontEnemy(data.AttackType) != null;
        animator.SetBool("isAtking", isInAtking);
    }
    public void PreviewDelete()
    {
        sprr.color = Color.red;
        isInPreview = true;
    }
    public void CancelPreview()
    {
        isInPreview = false;
        sprr.color = Color.white;
    }
}
