using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �C�|�X����ʧ@���A : �ݾ��B���ʡB����...
/// </summary>
public enum AniType { Idle, Run, Attack, Skill, Hurt, Dead}

public class AnimationCtrl : MonoBehaviour
{
    #region �����
    //�ʵe�����������m
    private Animator _animator;
    /// <summary>
    /// �ʵe�������~���f
    /// </summary>
    public Animator animator
    {
        get
        {
            //������饼����A�ϥΤ���GetComponentz�覡���o(�u�|�o�ͤ@��)
            if (_animator == null) _animator = GetComponent<Animator>();
            return _animator;
        }
    }
    //���ⱱ���������m
    private CharCtrl _charrCtrl;
    /// <summary>
    /// ���ⱱ�����~���f
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
    /// ����������ʵe���A
    /// </summary>
    public void SetAnimation(AniType type)
    {
        //�z�Ltype�����A����Run���ʧ@
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
    /// �]�w�S�w�ޯ�ʵe
    /// </summary>
    /// <param name="skillNum">�ޯ�ʵe�s��</param>
    public void SetSkillAniNum(int skillNum)
    {
        animator.SetInteger("SkillNum", skillNum);
    }

    public void SetAttackNum(int attackNum)
    {
        animator.SetInteger("AttackNum", attackNum);
    }

    /// <summary>
    /// �����ʵe�����A�ɶ��b�ϥΪ��\��Event
    /// </summary>
    public void AttackDone()
    {
        charrCtrl.AttackDone();
    }
    /// <summary>
    /// �ʵe�����A�ɶ��b�ϥΪ��\��Event
    /// </summary>
    public void ActionDone()
    {
        charrCtrl.InAction(false);
    }
    /// <summary>
    /// �ޯ�ʵeĲ�o�I�A�ɶ��b�ϥΪ��\��Event
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
