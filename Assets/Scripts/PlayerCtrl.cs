using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : CharCtrl
{
    #region �n�챱��Ѽ�
    //�n��Ѽƹ�����
    private Vector2 _stickPos;
    //�n��Ѽƹ�~���f
    /// <summary>
    /// �n��Ѽ� : ������LWASD�ηn��XY�b
    /// </summary>
    public Vector2 stickPos
    {
        get
        {
            //�ާ@�Ѽƹ���(�T�w���Ѽƨ��o�޿�)
            _stickPos.x = Input.GetAxis("Horizontal");
            _stickPos.y = Input.GetAxis("Vertical");
            //�^�ǹ�����
            return _stickPos;
        }
    }

    /// <summary>
    /// �P�_���a�O�_�����U������
    /// </summary>
    private bool stickActive
    {
        // �P�_stickPos���ȬO�_��0
        get { return stickPos != Vector2.zero; }
    }
    //�n��Ѽƹ������׸��
    private float _rotaAng;
    /// <summary>
    /// �n��Ѽ� : ���������ۨ�
    /// </summary>
    public float rotaAng
    {
        get
        {
            //��ʨ��ת��p�� : �H12�I���쬰0�סA�ηn���V�p�⧨�� * �n��X��V
            // Mathf.Sign() -> �u�|�^�Ǧ� 1 or -1�A�u�d�U���t��
            _rotaAng = Vector2.Angle(Vector2.up, stickPos) * Mathf.Sign(stickPos.x);
            //�^�Ƿn�짨�� + ���Y��ʨ���
            return _rotaAng + DataSystem.cameraAng;
        }
    }
 
    #endregion

    #region �ޯ�]�w
    [Header("�ޯફ��M��")]
    public List<GameObject> skills;

    [Header("�ޯ�۰���w�d��")]
    public float attackRange = 20f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //�q���t�Ϊ��a����w�n��
        DataSystem.SetPlayerCtrl(this);
        //�^����
        CtrlHP(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        if (DataSystem.ctrlLock) return;
        CharStatus();
        Attack();
        Move();  
    }

    /// <summary>
    /// ��s���⪬�A
    /// </summary>
    public override void CharStatus()
    {
        base.CharStatus();
        //���˴���
        if (Input.GetKeyDown(KeyCode.P))
        {
            CtrlHP(-3f);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Dead();
        }
    }

    /// <summary>
    /// ����첾�\�� : ���� & �e�i
    /// </summary>
    public void Move()
    {
        if (isMove && stickActive)
        {
            //���� Quaternion.AngleAxis( ��ʨ��� �A ��w���b�V )
            transform.rotation = Quaternion.AngleAxis(rotaAng , Vector3.up);
            //�I�s�ʧ@��� : �������A�� AniType.Run
            aniType = AniType.Run;
            ctrlSpeed = 1;
        }
        else
        {
            ctrlSpeed = 0;
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            aniType = AniType.Attack;
        }
    }



    private MonsterCtrl target
    {
        get
        {
            return DataSystem.AttackLock();
        }
    }
    public void Skill(int skillBtnNum)
    {
        if(target != null) transform.LookAt(target.transform);
        aniType = AniType.Skill;
        //������e�o�g���ޯ�s��
        //skillIndex = skillBtnNum;
        aniCtrl.SetSkillAniNum(skillBtnNum);
        //Invoke("SkillShoot", 0.5f);
        
    }

    public override void SkillShoot(int skillIndex)
    {
        Instantiate(skills[skillIndex], transform.position + Vector3.up, transform.rotation);
    }

    /// <summary>
    /// ���ͪ��a�M�ݪ����`�\��Ƽg
    /// </summary>
    public override void Dead()
    {
        base.Dead();
        //�C���������ާ@���O
        DataSystem.ShowUpGameOverPanel(true, "GAME OVER!!");
    }
}
