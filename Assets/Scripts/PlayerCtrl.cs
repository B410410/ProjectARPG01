using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : CharCtrl
{
    #region 搖桿控制參數
    //搖桿參數實體資料
    private Vector2 _stickPos;
    //搖桿參數對外接口
    /// <summary>
    /// 搖桿參數 : 對應鍵盤WASD或搖桿XY軸
    /// </summary>
    public Vector2 stickPos
    {
        get
        {
            //操作參數對應(固定的參數取得邏輯)
            _stickPos.x = Input.GetAxis("Horizontal");
            _stickPos.y = Input.GetAxis("Vertical");
            //回傳實體資料
            return _stickPos;
        }
    }

    /// <summary>
    /// 判斷玩家是否有按下移動鍵
    /// </summary>
    private bool stickActive
    {
        // 判斷stickPos的值是否為0
        get { return stickPos != Vector2.zero; }
    }
    //搖桿參數對應角度資料
    private float _rotaAng;
    /// <summary>
    /// 搖桿參數 : 對應的面相角
    /// </summary>
    public float rotaAng
    {
        get
        {
            //轉動角度的計算 : 以12點整方位為0度，用搖桿方向計算夾角 * 搖桿X方向
            // Mathf.Sign() -> 只會回傳成 1 or -1，只留下正負值
            _rotaAng = Vector2.Angle(Vector2.up, stickPos) * Mathf.Sign(stickPos.x);
            //回傳搖桿夾角 + 鏡頭轉動角度
            return _rotaAng + DataSystem.cameraAng;
        }
    }
 
    #endregion

    #region 技能設定
    [Header("技能物件清單")]
    public List<GameObject> skills;

    [Header("技能自動鎖定範圍")]
    public float attackRange = 20f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //通報系統玩家控制器已登場
        DataSystem.SetPlayerCtrl(this);
        //回滿血
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
    /// 更新角色狀態
    /// </summary>
    public override void CharStatus()
    {
        base.CharStatus();
        //受傷測試
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
    /// 角色位移功能 : 旋轉 & 前進
    /// </summary>
    public void Move()
    {
        if (isMove && stickActive)
        {
            //旋轉 Quaternion.AngleAxis( 轉動角度 ， 鎖定的軸向 )
            transform.rotation = Quaternion.AngleAxis(rotaAng , Vector3.up);
            //呼叫動作控制器 : 切換狀態至 AniType.Run
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
        //紀錄當前發射的技能編號
        //skillIndex = skillBtnNum;
        aniCtrl.SetSkillAniNum(skillBtnNum);
        //Invoke("SkillShoot", 0.5f);
        
    }

    public override void SkillShoot(int skillIndex)
    {
        Instantiate(skills[skillIndex], transform.position + Vector3.up, transform.rotation);
    }

    /// <summary>
    /// 產生玩家專屬的死亡功能複寫
    /// </summary>
    public override void Dead()
    {
        base.Dead();
        //遊戲結束的操作面板
        DataSystem.ShowUpGameOverPanel(true, "GAME OVER!!");
    }
}
