using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 使用RequireComponent使
/// UIPanelSwitchCtrl和CanvasGroup綁定 (必須同時存在)
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class UIPanelSwitchCtrl : MonoBehaviour
{
    private CanvasGroup _CG;
    public CanvasGroup CG
    {
        get
        {
            if (_CG == null) _CG = GetComponent<CanvasGroup>();
            return _CG;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Switch(bool B) 
    {
        //CanvasGroup是否可見
        CG.alpha = B ? 1: 0;
        //CanvasGroup是否可觸
        CG.blocksRaycasts = B;
    }
}
