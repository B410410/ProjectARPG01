using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �_�l�e���\��޲z
/// </summary>
public class StartScreenManager : MonoBehaviour
{
    /// <summary>
    /// �i�J�C��(���)
    /// </summary>
   public void StartGame()
    {
        //�����ܤU�@�ӳ���
        SceneManager.LoadScene("StageOption");
    }

    /// <summary>
    /// ���}�C��(����)
    /// </summary>
    public void QuitGame()
    {
        //�����C�� : ���X���� > ���( �O or �_ ) 
        Application.Quit();
    }

}
