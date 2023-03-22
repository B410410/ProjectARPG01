using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �����e���\��޲z
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
    [Header("���d����")]
    public Image stageImg;
    public List<Sprite> stagePics;

    public void Start()
    {
        stageIndex = DataSystem.selectStageNum + 1;
        stageImg.sprite = stagePics[stageIndex - 1];
    }

    /// <summary>
    /// ���ܫe�@�����d
    /// </summary>
    public void LeftStage()
    {
        stageIndex--;
        stageImg.sprite = stagePics[stageIndex - 1];
        DataSystem.selectStageName = "Stag" + stageIndex;
        DataSystem.selectStageNum = stageIndex - 1;
    }

    /// <summary>
    /// ���ܫ�@�����d
    /// </summary>
    public void RightStage()
    {
        stageIndex++;
        stageImg.sprite = stagePics[stageIndex - 1];
        DataSystem.selectStageName = "Stage"+ stageIndex;
        DataSystem.selectStageNum = stageIndex - 1;
    }

    /// <summary>
    /// �i�J��e��w(�ﶵ���d��m)�����d
    /// </summary>
    public void EnterStage()
    {
        //�i�J�C�����e�A���J�C������(GmaeUI)
        SceneManager.LoadScene("GameUI");
        //Debug.Log(DataSystem.selectStageName);
    }

    /// <summary>
    /// �h�^�_�l�e��
    /// </summary>
    public void BackToStartScreen()
    {
        //�����ܰ_�l�e��
        SceneManager.LoadScene("Start");
    }
}
