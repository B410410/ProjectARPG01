using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISkillCtrl : MonoBehaviour
{
    [Header("SkillBtn")]
    public TextMeshProUGUI skillKeyText;
    public KeyCode key;//��������L�X
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
    /// �O�_�B��N�o���A��
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
        //�������ܪ���l��
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
        {//�ޯ�Ĳ�o
            SkillTrigger();
        }   
    }

    /// <summary>
    /// �ޯ�Ĳ�o
    /// </summary>
    void SkillTrigger()
    {
        cd = cdTime;
        DataSystem.SkillTriggerChecker(btnNumber);
    }

    /// <summary>
    /// ��sUI����
    /// </summary>
    void UpdateCD()
    {
        //CD�}�l�˼�
        cd -= Time.deltaTime;
        //CD����������s
        skillCDImg.fillAmount = cdPrecent;
        skillCDText.text = cdPrecentStr;
    }
}
