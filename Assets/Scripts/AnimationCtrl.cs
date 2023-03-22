using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 列舉出角色動作狀態 : 待機、移動、攻擊...
/// </summary>
public enum AniType { Idle, Run, Attack, Skill, Hurt, Dead}

public class AnimationCtrl : MonoBehaviour
{
    #region 控制元件
    //動畫控制器元件實體位置
    private Animator _animator;
    /// <summary>
    /// 動畫控制器的對外接口
    /// </summary>
    public Animator animator
    {
        get
        {
            //控制器實體未抓取，使用內建GetComponentz方式取得(只會發生一次)
            if (_animator == null) _animator = GetComponent<Animator>();
            return _animator;
        }
    }
    //角色控制器元件實體位置
    private CharCtrl _charrCtrl;
    /// <summary>
    /// 角色控制器的對外接口
    /// </summary>
    public CharCtrl charrCtrl
    {
        get
        {
            if (_charrCtrl == null) _charrCtrl = GetComponentInParent<CharCtrl>();
            return _charrCtrl;
        }
    }
    #endregion

    /// <summary>
    /// 執行對應的動畫狀態
    /// </summary>
    public void SetAnimation(AniType type)
    {
        //透過type的狀態切換Run的動作
        animator.SetBool("Run", type == AniType.Run);
        animator.SetBool("Attack", type == AniType.Attack);
        animator.SetBool("Skill", type == AniType.Skill);
        if (type == AniType.Hurt) 
        {
            animator.SetTrigger("Hurt");
            charrCtrl.InAction(true);
        } 
        if(type == AniType.Dead)
        {
            animator.SetTrigger("Dead");
            charrCtrl.InAction(true);
        }
    }
    /// <summary>
    /// 設定特定技能動畫
    /// </summary>
    /// <param name="skillNum">技能動畫編號</param>
    public void SetSkillAniNum(int skillNum)
    {
        animator.SetInteger("SkillNum", skillNum);
    }

    public void SetAttackNum(int attackNum)
    {
        animator.SetInteger("AttackNum", attackNum);
    }

    /// <summary>
    /// 攻擊動畫結束，時間軸使用的功能Event
    /// </summary>
    public void AttackDone()
    {
        charrCtrl.AttackDone();
    }
    /// <summary>
    /// 動畫結束，時間軸使用的功能Event
    /// </summary>
    public void ActionDone()
    {
        charrCtrl.InAction(false);
    }
    /// <summary>
    /// 技能動畫觸發點，時間軸使用的功能Event
    /// </summary>
    public void SkillShoot(int skillIndex)
    {
        charrCtrl.SkillShoot(skillIndex);
    }

    public void DestroyEvent()
    {
        charrCtrl.Destroy();
    }
}
