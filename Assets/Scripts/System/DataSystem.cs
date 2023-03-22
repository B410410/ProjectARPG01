using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 遊戲進行中管理與存放資料的系統腳本
/// </summary>
public static class DataSystem 
{
    /// <summary>
    /// 遊戲操作鎖定
    /// </summary>
    public static bool ctrlLock = false;

    #region 關卡相關資料
    /// <summary>
    /// 紀錄當前選取的關卡名稱
    /// </summary>
    public static string selectStageName = "Stage1";
    public static int selectStageNum = 0;
    /// <summary>
    /// 關卡進程中的門鎖
    /// </summary>
    public static StageBlockEvent stageBlockEvent;
    private static BGMPlayer _bgmPlayer;

    public static void SetBGMPlayer(BGMPlayer bgmPlayer)
    {
        _bgmPlayer = bgmPlayer;
    }
    public static void StageMusicPlay()
    {
        _bgmPlayer.PlayMusic(selectStageNum);
    }

    public static void SetBGMVol(float vol)
    {
        _bgmPlayer.SetBGMVol(vol);
    }
    #endregion

    #region UI相關
    private static GameUIManager gameUIManager;
    /// <summary>
    /// 設定遊戲主UI管理
    /// </summary>
    /// <param name="manager"></param>
    public static void SetGameUIManager(GameUIManager manager)
    {
        gameUIManager = manager;
    }
    /// <summary>
    /// 呼叫GameOverPanel出現或消失
    /// </summary>
    public static void ShowUpGameOverPanel(bool B, string mag = "")
    {
        gameUIManager.GameOverPanelSwitch(B, mag);
    } 
    #endregion

    #region 玩家資料
    /// <summary>
    /// 玩家控制器的物件
    /// </summary>
    private static PlayerCtrl playerCtrl;
    /// <summary>
    /// 鏡頭焦點管理物件
    /// </summary>
    private static CameraTargetManager cameraTarget;
    /// <summary>
    /// 玩家控制介面物件
    /// </summary>
    private static UIPlayerHpBarCtrl playerHpBar;
    
    public static PlayerCtrl monstertarget
    {
        get
        {
            return playerCtrl;
        }
    }

    /// <summary>
    /// 玩家的實時的座標位置
    /// </summary>
    public static Vector3 playerPos
    {
        get
        {
            if (playerCtrl != null)
            {
                return playerCtrl.transform.position;
            }
            else
            {
                //玩家不存在時，鏡頭原地待命
                return cameraTarget.transform.position;
            }
        }
    }
    /// <summary>
    /// 鏡頭旋轉偏移角度
    /// </summary>
    public static float cameraAng
    {
        get
        {
            //呼叫尤拉幫忙，取得Y軸正確數據
            return cameraTarget.transform.rotation.eulerAngles.y;
        }
    }
    /// <summary>
    /// 設定玩家控制器
    /// </summary>
    /// <param name="ctrl">玩家控制器</param>
    public static void SetPlayerCtrl(PlayerCtrl ctrl)
    {
        playerCtrl = ctrl;
        if (cameraTarget != null)
        {
            //擺正鏡位到玩家面向
            cameraTarget.transform.rotation = playerCtrl.transform.rotation;
        }
    }

    /// <summary>
    /// 設定鏡頭焦點管理物件
    /// </summary>
    /// <param name="target">鏡頭焦點管理物件</param>
    public static void SetCameraTarget(CameraTargetManager target)
    {
        cameraTarget = target;
    }

    /// <summary>
    /// 設定玩家HP介面控制器
    /// </summary>
    /// <param name="ctrl">玩家控制器</param>
    public static void SetPlayerHpBarCtrl(UIPlayerHpBarCtrl hpBarCtrl)
    {
        playerHpBar = hpBarCtrl;
        if (playerCtrl != null)
        {
            //執行初始更新
            playerHpBar.UpdateUI();
        }
    }
    /// <summary>
    /// 更新Player的UI介面
    /// </summary>
    public static void UpdatePlayerUI()
    {
        if (playerHpBar != null)
        {
            //執行初始更新
            playerHpBar.UpdateUI();
        }
    }
    public static float PlayerHpPrecent()
    {
        return playerCtrl.hp / playerCtrl.maxHp; 
    }
    public static string PlayerHpString()
    {
        return playerCtrl.hp.ToString() + "/" + playerCtrl.maxHp.ToString();
    }
    #endregion

    #region 技能系統
    /// <summary>
    /// 登場怪物清單
    /// </summary>
    private static List<MonsterCtrl> monsterList = new List<MonsterCtrl>();
    public static void AddMonster(MonsterCtrl monster)
    {
        monsterList.Add(monster);
    }
    public static void RemoveMonster(MonsterCtrl monster)
    {
        monsterList.Remove(monster);
    }
    public static MonsterCtrl AttackLock()
    {
        MonsterCtrl monster = null;
        float range = 999;
        foreach(MonsterCtrl ctrl in monsterList)
        {
            float dis = Vector3.Distance(ctrl.transform.position, playerPos);
            if (dis <= playerCtrl.attackRange && dis <= range)
            {
                range = dis;
                monster = ctrl;
            }
        }
        return monster;
    }

    /// <summary>
    /// 技能UI案件觸發事件
    /// </summary>
    public static Action skillTriggerEvent;

    public static void SkillTriggerChecker(int skillBtnNum)
    {
        if(skillTriggerEvent != null)
        {
            playerCtrl.Skill(skillBtnNum);
        }
    }
    #endregion
}
