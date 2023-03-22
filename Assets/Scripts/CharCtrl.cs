using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharCtrl : MonoBehaviour
{
    /// <summary>
    /// 當前角色行為狀態
    /// </summary>
    protected AniType aniType;

    #region 控制元件
    private CharacterController _charCtrl;
    public CharacterController charCtrl
    {
        get
        {
            if (_charCtrl == null) _charCtrl = GetComponent<CharacterController>();
            return _charCtrl;
        }
    }

    private AnimationCtrl _aniCtrl;
    public AnimationCtrl aniCtrl
    {
        get
        {
            //元件在子物件層，使用GetComponentInChildren抓取
            if (_aniCtrl == null) _aniCtrl = GetComponentInChildren<AnimationCtrl>();
            return _aniCtrl;
        }
    }
    #endregion

    #region 角色行為狀態
    /// <summary>
    /// 人物待機
    /// </summary>
    protected bool isIdle
    {
        get
        {
            return !isDead && !isHurt && !isAttack && ctrlSpeed == 0;
        }
    }
    /// <summary>
    /// 人物是否正在操作移動
    /// </summary>
    protected bool isMove
    {
        get
        {//需要未處於(攻擊、受傷、死亡)狀態 && 虛擬搖桿直軸 or 橫軸不為 0 : 正在移動 
            return !(isAttack || isHurt || isDead);
        }
    }
    /// <summary>
    /// 是否處於攻擊行為中
    /// </summary>
    protected bool isAttack
    {
        get
        {
            return aniType == AniType.Attack || aniType == AniType.Skill;
        }
    }
    /// <summary>
    /// 是否處於受到傷害行為中
    /// </summary>
    protected bool isHurt
    {
        get
        {
            return aniType == AniType.Hurt;
        }
    }

    /// <summary>
    /// 硬直動作中 : 攻擊/受擊/死亡....
    /// </summary>
    protected bool actRecover = false;
    #endregion

    #region 角色控制參數
    [Header("控制參數")]
    [Range(1f, 20f)]
    public float moveSpeed = 3f;
    protected float ctrlSpeed = 0;
    /// <summary>
    /// 重力常數
    /// </summary>
    public const float gravity = -9.8f;
    /// <summary>
    /// 角色動量參數實體資料
    /// </summary>
    private Vector3 _moveVet;
    /// <summary>
    /// 角色動量參數接口
    /// </summary>
    private Vector3 moveVet
    {
        get
        {
            _moveVet.y = gravity;
            Vector3 foeward =transform.forward * moveSpeed * ctrlSpeed;
            return (_moveVet + foeward) * Time.deltaTime;
        }
    }
    #endregion

    #region 角色遊戲數據
    [Header("血量設定")]
    public float maxHp = 100f;
    /// <summary>
    /// 實體血量數據
    /// </summary>
    protected float _hp = 1f;
    /// <summary>
    /// 血量數據控制接口
    /// </summary>
    public float hp
    {
        get
        {
            return _hp;
        }
        protected set
        {
            _hp = value;
            if (_hp > maxHp) _hp = maxHp;
            if (_hp <= 0) _hp = 0;
        }
    }
    #endregion

    /// <summary>
    /// 更新角色狀態
    /// </summary>
    public virtual void CharStatus()
    {
        //處於動作恢復狀態下 : 阻斷其他動作發生
        if (actRecover) return;
        if (isIdle)
        {
            //呼叫動作控制器 : 切換狀態至 AniType.Idle
            aniType = AniType.Idle;
        }
        //人物角色的動量
        charCtrl.Move(moveVet);
        aniCtrl.SetAnimation(aniType);
    }

    /// <summary>
    /// 是否處於死亡狀態下
    /// </summary>
    protected bool isDead
    {
        get
        {
            return hp <= 0;
        }
    }
    /// <summary>
    /// 血量控制
    /// </summary>
    /// <param name="f">數值</param>
    public void CtrlHP(float f)
    {
        if (f < 0)
        {
            aniType = AniType.Hurt;
            Debug.Log("造成傷害 : " + -f);
        }
        else
        {
            Debug.Log("治療生命 : " + f);
        }
        //hp內建最大最小直的運算 0 <= hp <= maxHp
        hp += f; Debug.Log(hp);
        DataSystem.UpdatePlayerUI();
        //HP歸零會執行死亡
        if (isDead)
        {
            Dead();
        }
    }
    /// <summary>
    /// 處於硬直狀態設定
    /// </summary>
    /// <param name="B">是否硬直</param>
    public virtual void InAction(bool B)
    {
        actRecover = B;
        //呼叫動作控制器 : 切換狀態至 AniType.Idle
        if (!B) aniType = AniType.Idle;
    }

    /// <summary>
    /// 接受動畫系統的Event用的功能
    /// </summary>
    public virtual void AttackDone()
    {
        //呼叫動作控制器 : 切換狀態至 AniType.Idle
        aniType = AniType.Idle;
    }

    public abstract void SkillShoot(int skillIndex);

    /// <summary>
    /// 角色死亡
    /// </summary>
    public virtual void Dead()
    {
        aniType = AniType.Dead;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
