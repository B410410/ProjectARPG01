using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 選關畫面功能管理
/// </summary>
public class SelectStageManager : MonoBehaviour
{
    private int _stageIndex = 1;
    public int stageIndex
    {
        get
        {
            return _stageIndex;
        }
        set
        {
            _stageIndex = value;
            if (_stageIndex > 3) _stageIndex = 1;
            if (_stageIndex < 1) _stageIndex = 3;
            Debug.Log(stageIndex);
        }
    }
    [Header("關卡場景")]
    public Image stageImg;
    public List<Sprite> stagePics;

    public void Start()
    {
        stageIndex = DataSystem.selectStageNum + 1;
        stageImg.sprite = stagePics[stageIndex - 1];
    }

    /// <summary>
    /// 移至前一個關卡
    /// </summary>
    public void LeftStage()
    {
        stageIndex--;
        stageImg.sprite = stagePics[stageIndex - 1];
        DataSystem.selectStageName = "Stag" + stageIndex;
        DataSystem.selectStageNum = stageIndex - 1;
    }

    /// <summary>
    /// 移至後一個關卡
    /// </summary>
    public void RightStage()
    {
        stageIndex++;
        stageImg.sprite = stagePics[stageIndex - 1];
        DataSystem.selectStageName = "Stage"+ stageIndex;
        DataSystem.selectStageNum = stageIndex - 1;
    }

    /// <summary>
    /// 進入當前鎖定(選項停留位置)的關卡
    /// </summary>
    public void EnterStage()
    {
        //進入遊戲內容，載入遊戲介面(GmaeUI)
        SceneManager.LoadScene("GameUI");
        //Debug.Log(DataSystem.selectStageName);
    }

    /// <summary>
    /// 退回起始畫面
    /// </summary>
    public void BackToStartScreen()
    {
        //切換至起始畫面
        SceneManager.LoadScene("Start");
    }
}
