using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharCtrl : MonoBehaviour
{
    /// <summary>
    /// ��e����欰���A
    /// </summary>
    protected AniType aniType;

    #region �����
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
            //����b�l����h�A�ϥ�GetComponentInChildren���
            if (_aniCtrl == null) _aniCtrl = GetComponentInChildren<AnimationCtrl>();
            return _aniCtrl;
        }
    }
    #endregion

    #region ����欰���A
    /// <summary>
    /// �H���ݾ�
    /// </summary>
    protected bool isIdle
    {
        get
        {
            return !isDead && !isHurt && !isAttack && ctrlSpeed == 0;
        }
    }
    /// <summary>
    /// �H���O�_���b�ާ@����
    /// </summary>
    protected bool isMove
    {
        get
        {//�ݭn���B��(�����B���ˡB���`)���A && �����n�쪽�b or ��b���� 0 : ���b���� 
            return !(isAttack || isHurt || isDead);
        }
    }
    /// <summary>
    /// �O�_�B������欰��
    /// </summary>
    protected bool isAttack
    {
        get
        {
            return aniType == AniType.Attack || aniType == AniType.Skill;
        }
    }
    /// <summary>
    /// �O�_�B�����ˮ`�欰��
    /// </summary>
    protected bool isHurt
    {
        get
        {
            return aniType == AniType.Hurt;
        }
    }

    /// <summary>
    /// �w���ʧ@�� : ����/����/���`....
    /// </summary>
    protected bool actRecover = false;
    #endregion

    #region ���ⱱ��Ѽ�
    [Header("����Ѽ�")]
    [Range(1f, 20f)]
    public float moveSpeed = 3f;
    protected float ctrlSpeed = 0;
    /// <summary>
    /// ���O�`��
    /// </summary>
    public const float gravity = -9.8f;
    /// <summary>
    /// ����ʶq�Ѽƹ�����
    /// </summary>
    private Vector3 _moveVet;
    /// <summary>
    /// ����ʶq�ѼƱ��f
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

    #region ����C���ƾ�
    [Header("��q�]�w")]
    public float maxHp = 100f;
    /// <summary>
    /// �����q�ƾ�
    /// </summary>
    protected float _hp = 1f;
    /// <summary>
    /// ��q�ƾڱ���f
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
    /// ��s���⪬�A
    /// </summary>
    public virtual void CharStatus()
    {
        //�B��ʧ@��_���A�U : ���_��L�ʧ@�o��
        if (actRecover) return;
        if (isIdle)
        {
            //�I�s�ʧ@��� : �������A�� AniType.Idle
            aniType = AniType.Idle;
        }
        //�H�����⪺�ʶq
        charCtrl.Move(moveVet);
        aniCtrl.SetAnimation(aniType);
    }

    /// <summary>
    /// �O�_�B�󦺤`���A�U
    /// </summary>
    protected bool isDead
    {
        get
        {
            return hp <= 0;
        }
    }
    /// <summary>
    /// ��q����
    /// </summary>
    /// <param name="f">�ƭ�</param>
    public void CtrlHP(float f)
    {
        if (f < 0)
        {
            aniType = AniType.Hurt;
            Debug.Log("�y���ˮ` : " + -f);
        }
        else
        {
            Debug.Log("�v���ͩR : " + f);
        }
        //hp���س̤j�̤p�����B�� 0 <= hp <= maxHp
        hp += f; Debug.Log(hp);
        DataSystem.UpdatePlayerUI();
        //HP�k�s�|���榺�`
        if (isDead)
        {
            Dead();
        }
    }
    /// <summary>
    /// �B��w�����A�]�w
    /// </summary>
    /// <param name="B">�O�_�w��</param>
    public virtual void InAction(bool B)
    {
        actRecover = B;
        //�I�s�ʧ@��� : �������A�� AniType.Idle
        if (!B) aniType = AniType.Idle;
    }

    /// <summary>
    /// �����ʵe�t�Ϊ�Event�Ϊ��\��
    /// </summary>
    public virtual void AttackDone()
    {
        //�I�s�ʧ@��� : �������A�� AniType.Idle
        aniType = AniType.Idle;
    }

    public abstract void SkillShoot(int skillIndex);

    /// <summary>
    /// ���⦺�`
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
