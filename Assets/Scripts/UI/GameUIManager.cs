using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [Header("�C����歱�O")]
    public UIPanelSwitchCtrl optionPanel;
    [Header("�C�������ﶵ���O")]
    public UIPanelSwitchCtrl gameOverPanel;
    public TextMeshProUGUI gameMsg;

    // Start is called before the first frame update
    void Start()
    {
        DataSystem.SetGameUIManager(this);
        Debug.Log(DataSystem.selectStageName);
        //���J������d���(���|�[����k�A�O�dUI������)
        SceneManager.LoadScene(DataSystem.selectStageName, LoadSceneMode.Additive);
    }

    /// <summary>
    /// ����GameOverPanel�����
    /// </summary>
    /// <param name="B">�X�{ : true or ���� : false</param>
    public void GameOverPanelSwitch(bool B, string mag)
    {
        gameOverPanel.Switch(B);
        gameMsg.text = mag;
    }

    /// <summary>
    /// �^���d����
    /// </summary>
    public void BackToMenu()
    {
        //�����ܤU�@�ӳ���
        SceneManager.LoadScene("StageOption");
    }
}
