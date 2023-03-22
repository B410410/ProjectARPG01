using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [Header("遊戲選單面板")]
    public UIPanelSwitchCtrl optionPanel;
    [Header("遊戲結束選項面板")]
    public UIPanelSwitchCtrl gameOverPanel;
    public TextMeshProUGUI gameMsg;

    // Start is called before the first frame update
    void Start()
    {
        DataSystem.SetGameUIManager(this);
        Debug.Log(DataSystem.selectStageName);
        //載入選取關卡資料(用疊加的方法，保留UI的部分)
        SceneManager.LoadScene(DataSystem.selectStageName, LoadSceneMode.Additive);
    }

    /// <summary>
    /// 控制GameOverPanel的顯示
    /// </summary>
    /// <param name="B">出現 : true or 隱藏 : false</param>
    public void GameOverPanelSwitch(bool B, string mag)
    {
        gameOverPanel.Switch(B);
        gameMsg.text = mag;
    }

    /// <summary>
    /// 回關卡選單用
    /// </summary>
    public void BackToMenu()
    {
        //切換至下一個場景
        SceneManager.LoadScene("StageOption");
    }
}
