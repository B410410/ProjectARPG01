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
    [Header("門鎖特效")]
    public GameObject lockEffect;

    [Header("解鎖條件")]
    public int monsterCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 門鎖解鎖怪物數量增加
    /// </summary>
    public void AddMonsterCount()
    {
        monsterCount++;
        Debug.Log("登場怪物數量 : " + monsterCount);
    }

    /// <summary>
    /// 上鎖功能
    /// </summary>
    /// <param name="B">true = 鎖上 / false = 開啟</param>
    public void LockDoor(bool B)
    {
        if (B)
        {//鎖上
            boxCollider.isTrigger = false;
            lockEffect.SetActive(true);
        }
        else
        {//開啟
            boxCollider.isTrigger = true;
            lockEffect.SetActive(false);
        }
    }

    /// <summary>
    /// 通知遊戲系統當前關卡門鎖
    /// </summary>
    public void SetStageBlock()
    {
        DataSystem.stageBlockEvent = this;
        Debug.Log("區域鎖定.....!");
        LockDoor(true);
    }

    /// <summary>
    /// 解鎖檢查(怪物死亡時呼叫)
    /// </summary>
    public void UnlockChecker()
    {
        monsterCount--;
        if(monsterCount <= 0)
        {
            Debug.Log("區域解鎖!");
            LockDoor(false);
        }
    }

    public void OpenDoor()
    {
        boxCollider.isTrigger = true;
        lockEffect.SetActive(false);
    }

}
