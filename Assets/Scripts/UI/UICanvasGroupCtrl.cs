using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�j�w�Ӹ}���P�ɱ��� : �קK�ѰO�˸��n�����H
[RequireComponent(typeof(CanvasGroup))]
/// <summary>
/// UI���O�s�ձ���
/// </summary>
public class UICanvasGroupCtrl : MonoBehaviour
{
    [Header("UI�s�դ���(�m�JCanvasGroup)")]
    //���O�s�ժ�������ܼ����
    public CanvasGroup CG;
    public Animator animator;

    [Header("�w�]�O�_���")]
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

    #region ���]�t�ʵe���}��/�������O�\��
    /// <summary>
    /// �}��UI�s�խ��O
    /// </summary>
    public void Open()
    {
        CG.alpha = 1;
        ; CG.blocksRaycasts = true;
    }

    /// <summary>
    /// ����UI�s�խ��O
    /// </summary>
    public void Close()
    {
        CG.alpha = 0;
        CG.blocksRaycasts = false;
    }
    #endregion

    #region ���[�ʵe���}��/�������O�\��
    /// <summary>
    /// �}��UI�s�խ��O
    /// </summary>
    public void OpenWithAnimation()
    {
        //�I�s�ʵe�t��
        animator.Play("Open State");
        ; CG.blocksRaycasts = true;
    }

    /// <summary>
    /// ����UI�s�խ��O
    /// </summary>
    public void CloseWithAnimation()
    {
        //�I�s�ʵe�t��
        animator.Play("Close State");
        CG.blocksRaycasts = false;
    }
    #endregion







}