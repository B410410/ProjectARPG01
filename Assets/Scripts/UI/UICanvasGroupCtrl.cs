using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//綁定該腳本同時掛載 : 避免忘記裝載要控制的對象
[RequireComponent(typeof(CanvasGroup))]
/// <summary>
/// UI面板群組控制
/// </summary>
public class UICanvasGroupCtrl : MonoBehaviour
{
    [Header("UI群組元件(置入CanvasGroup)")]
    //面板群組物件實體變數欄位
    public CanvasGroup CG;
    public Animator animator;

    [Header("預設是否顯示")]
    public bool showForStart;

    // Start is called before the first frame update
    void Start()
    {
        if (showForStart)
        {
            //true
            Open();
        }
        else
        {
            //false
            Close();
        }
    }

    #region 不包含動畫的開啟/關閉面板功能
    /// <summary>
    /// 開啟UI群組面板
    /// </summary>
    public void Open()
    {
        CG.alpha = 1;
        ; CG.blocksRaycasts = true;
    }

    /// <summary>
    /// 關閉UI群組面板
    /// </summary>
    public void Close()
    {
        CG.alpha = 0;
        CG.blocksRaycasts = false;
    }
    #endregion

    #region 附加動畫的開啟/關閉面板功能
    /// <summary>
    /// 開啟UI群組面板
    /// </summary>
    public void OpenWithAnimation()
    {
        //呼叫動畫系統
        animator.Play("Open State");
        ; CG.blocksRaycasts = true;
    }

    /// <summary>
    /// 關閉UI群組面板
    /// </summary>
    public void CloseWithAnimation()
    {
        //呼叫動畫系統
        animator.Play("Close State");
        CG.blocksRaycasts = false;
    }
    #endregion







}