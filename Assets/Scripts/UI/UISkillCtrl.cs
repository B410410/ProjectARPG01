using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISkillCtrl : MonoBehaviour
{
    [Header("SkillBtn")]
    public TextMeshProUGUI skillKeyText;
    public KeyCode key;//全部的鍵盤碼
    public int btnNumber;

    [Header("Skill CD")]
    public Image skillCDImg;
    public float cdTime = 1f;
    private float cd = 0f;
    private float cdPrecent
    {
        get
        {
            return cd / cdTime;
        }
    }

    public TextMeshProUGUI skillCDText;
    private string cdPrecentStr
    {
        get
        {
            return inCoolDown ? cd.ToString("F1") : string.Empty;
        }
    }
    /// <summary>
    /// 是否處於冷卻狀態中
    /// </summary>
    private bool inCoolDown
    {
        get
        {
            return cd > 0 ;
        }   
    }
    // Start is called before the first frame update
    void Start()
    {
        DataSystem.skillTriggerEvent += SkillTrigger;

        UpdateCD();
        //介面提示的初始化
        skillKeyText.text = key.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(inCoolDown)
        {
            UpdateCD();
        }
        else if (Input.GetKeyDown(key))
        {//技能觸發
            SkillTrigger();
        }   
    }

    /// <summary>
    /// 技能觸發
    /// </summary>
    void SkillTrigger()
    {
        cd = cdTime;
        DataSystem.SkillTriggerChecker(btnNumber);
    }

    /// <summary>
    /// 更新UI介面
    /// </summary>
    void UpdateCD()
    {
        //CD開始倒數
        cd -= Time.deltaTime;
        //CD相關介面更新
        skillCDImg.fillAmount = cdPrecent;
        skillCDText.text = cdPrecentStr;
    }
}
