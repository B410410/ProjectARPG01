using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBlockEvent : MonoBehaviour
{
    private BoxCollider _boxCollider;
    public BoxCollider boxCollider
    {
        get
        {
            if (_boxCollider == null) _boxCollider = GetComponent<BoxCollider>();
            return _boxCollider;
        }
    }
    [Header("����S��")]
    public GameObject lockEffect;

    [Header("�������")]
    public int monsterCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// �������Ǫ��ƶq�W�[
    /// </summary>
    public void AddMonsterCount()
    {
        monsterCount++;
        Debug.Log("�n���Ǫ��ƶq : " + monsterCount);
    }

    /// <summary>
    /// �W��\��
    /// </summary>
    /// <param name="B">true = ��W / false = �}��</param>
    public void LockDoor(bool B)
    {
        if (B)
        {//��W
            boxCollider.isTrigger = false;
            lockEffect.SetActive(true);
        }
        else
        {//�}��
            boxCollider.isTrigger = true;
            lockEffect.SetActive(false);
        }
    }

    /// <summary>
    /// �q���C���t�η�e���d����
    /// </summary>
    public void SetStageBlock()
    {
        DataSystem.stageBlockEvent = this;
        Debug.Log("�ϰ���w.....!");
        LockDoor(true);
    }

    /// <summary>
    /// �����ˬd(�Ǫ����`�ɩI�s)
    /// </summary>
    public void UnlockChecker()
    {
        monsterCount--;
        if(monsterCount <= 0)
        {
            Debug.Log("�ϰ����!");
            LockDoor(false);
        }
    }

    public void OpenDoor()
    {
        boxCollider.isTrigger = true;
        lockEffect.SetActive(false);
    }

}
