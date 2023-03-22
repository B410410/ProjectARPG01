using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 起始畫面功能管理
/// </summary>
public class StartScreenManager : MonoBehaviour
{
    /// <summary>
    /// 進入遊戲(選單)
    /// </summary>
   public void StartGame()
    {
        //切換至下一個場景
        SceneManager.LoadScene("StageOption");
    }

    /// <summary>
    /// 離開遊戲(關閉)
    /// </summary>
    public void QuitGame()
    {
        //關閉遊戲 : 跳出提示 > 選擇( 是 or 否 ) 
        Application.Quit();
    }

}
