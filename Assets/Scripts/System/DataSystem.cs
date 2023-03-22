using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �C���i�椤�޲z�P�s���ƪ��t�θ}��
/// </summary>
public static class DataSystem 
{
    /// <summary>
    /// �C���ާ@��w
    /// </summary>
    public static bool ctrlLock = false;

    #region ���d�������
    /// <summary>
    /// ������e��������d�W��
    /// </summary>
    public static string selectStageName = "Stage1";
    public static int selectStageNum = 0;
    /// <summary>
    /// ���d�i�{��������
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

    #region UI����
    private static GameUIManager gameUIManager;
    /// <summary>
    /// �]�w�C���DUI�޲z
    /// </summary>
    /// <param name="manager"></param>
    public static void SetGameUIManager(GameUIManager manager)
    {
        gameUIManager = manager;
    }
    /// <summary>
    /// �I�sGameOverPanel�X�{�ή���
    /// </summary>
    public static void ShowUpGameOverPanel(bool B, string mag = "")
    {
        gameUIManager.GameOverPanelSwitch(B, mag);
    } 
    #endregion

    #region ���a���
    /// <summary>
    /// ���a���������
    /// </summary>
    private static PlayerCtrl playerCtrl;
    /// <summary>
    /// ���Y�J�I�޲z����
    /// </summary>
    private static CameraTargetManager cameraTarget;
    /// <summary>
    /// ���a���������
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
    /// ���a����ɪ��y�Ц�m
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
                //���a���s�b�ɡA���Y��a�ݩR
                return cameraTarget.transform.position;
            }
        }
    }
    /// <summary>
    /// ���Y���ా������
    /// </summary>
    public static float cameraAng
    {
        get
        {
            //�I�s�ש������A���oY�b���T�ƾ�
            return cameraTarget.transform.rotation.eulerAngles.y;
        }
    }
    /// <summary>
    /// �]�w���a���
    /// </summary>
    /// <param name="ctrl">���a���</param>
    public static void SetPlayerCtrl(PlayerCtrl ctrl)
    {
        playerCtrl = ctrl;
        if (cameraTarget != null)
        {
            //�\�����쪱�a���V
            cameraTarget.transform.rotation = playerCtrl.transform.rotation;
        }
    }

    /// <summary>
    /// �]�w���Y�J�I�޲z����
    /// </summary>
    /// <param name="target">���Y�J�I�޲z����</param>
    public static void SetCameraTarget(CameraTargetManager target)
    {
        cameraTarget = target;
    }

    /// <summary>
    /// �]�w���aHP�������
    /// </summary>
    /// <param name="ctrl">���a���</param>
    public static void SetPlayerHpBarCtrl(UIPlayerHpBarCtrl hpBarCtrl)
    {
        playerHpBar = hpBarCtrl;
        if (playerCtrl != null)
        {
            //�����l��s
            playerHpBar.UpdateUI();
        }
    }
    /// <summary>
    /// ��sPlayer��UI����
    /// </summary>
    public static void UpdatePlayerUI()
    {
        if (playerHpBar != null)
        {
            //�����l��s
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

    #region �ޯ�t��
    /// <summary>
    /// �n���Ǫ��M��
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
    /// �ޯ�UI�ץ�Ĳ�o�ƥ�
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
