using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : CharCtrl
{
    [Header("�j���Z��")]
    public float searchRange = 10f;
    [Header("�����Z��")]
    public float attackRange = 2f;
    [Header("���q����")]
    public GameObject normaAttack;

    private PlayerCtrl target
    {
        get
        {
            return DataSystem.monstertarget;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //�z�L�t�γq������ �ϰ����˩Ǫ��ƶq�W�[
        DataSystem.stageBlockEvent.AddMonsterCount();
        ///�z�L�t�γq���i��w���Ǫ��i�J�M��
        DataSystem.AddMonster(this);
        CtrlHP(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        CharStatus();
        Action();
    }

    /// <summary>
    /// �Ǫ��欰AI(²���޿�)
    /// </summary>
    void Action()
    {
        if(!target || isAttack) return;
        if (Vector3.Distance(transform.position, DataSystem.playerPos) <= attackRange)
        {
            //(0,4) => �q0�}�l�A�n4�Ӹ��X(0,1,2,3)
            aniCtrl.SetAttackNum(Random.Range(0,4));
            aniType = AniType.Attack;
            ctrlSpeed = 0;
        }
        else if (Vector3.Distance(transform.position, DataSystem.playerPos) <= searchRange) 
        {
            transform.LookAt(DataSystem.playerPos);
            //�I�s�ʧ@��� : �������A�� AniType.Run
            aniType = AniType.Run;
            ctrlSpeed = 1;
        }
        else
        {
            ctrlSpeed = 0;
        }
    }

    public override void Dead()
    {
        //��H���O����l���{���X�A��base�I�s
        base.Dead();
        //�мg��s�W�����e�A�����`�ʵe�����~�P��
        DataSystem.stageBlockEvent.UnlockChecker();
        DataSystem.RemoveMonster(this);
    }

    public override void SkillShoot(int skillIndex)
    {
        Instantiate(normaAttack, transform.position + transform.forward * 2 + Vector3.up, transform.rotation);
    }
}
