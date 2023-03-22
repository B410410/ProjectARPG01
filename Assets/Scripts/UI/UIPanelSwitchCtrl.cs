using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ϥ�RequireComponent��
/// UIPanelSwitchCtrl�MCanvasGroup�j�w (�����P�ɦs�b)
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
        //CanvasGroup�O�_�i��
        CG.alpha = B ? 1: 0;
        //CanvasGroup�O�_�iĲ
        CG.blocksRaycasts = B;
    }
}
