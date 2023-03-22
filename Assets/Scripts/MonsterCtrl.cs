using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : CharCtrl
{
    [Header("搜索距離")]
    public float searchRange = 10f;
    [Header("攻擊距離")]
    public float attackRange = 2f;
    [Header("普通攻擊")]
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
        //透過系統通報門鎖 區域擊倒怪物數量增加
        DataSystem.stageBlockEvent.AddMonsterCount();
        ///透過系統通報可鎖定的怪物進入清單
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
    /// 怪物行為AI(簡易邏輯)
    /// </summary>
    void Action()
    {
        if(!target || isAttack) return;
        if (Vector3.Distance(transform.position, DataSystem.playerPos) <= attackRange)
        {
            //(0,4) => 從0開始，要4個號碼(0,1,2,3)
            aniCtrl.SetAttackNum(Random.Range(0,4));
            aniType = AniType.Attack;
            ctrlSpeed = 0;
        }
        else if (Vector3.Distance(transform.position, DataSystem.playerPos) <= searchRange) 
        {
            transform.LookAt(DataSystem.playerPos);
            //呼叫動作控制器 : 切換狀態至 AniType.Run
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
        //抽象類別中原始的程式碼，用base呼叫
        base.Dead();
        //覆寫後新增的內容，等死亡動畫結束才銷毀
        DataSystem.stageBlockEvent.UnlockChecker();
        DataSystem.RemoveMonster(this);
    }

    public override void SkillShoot(int skillIndex)
    {
        Instantiate(normaAttack, transform.position + transform.forward * 2 + Vector3.up, transform.rotation);
    }
}
