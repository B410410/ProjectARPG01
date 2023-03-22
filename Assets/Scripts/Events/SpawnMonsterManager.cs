using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterManager : MonoBehaviour
{
    /// <summary>
    /// 生怪點清單實體資料位置
    /// </summary>
    private List<SpawnPoint> _spawnPoints;
    /// <summary>
    /// 生怪點清單的對外接口
    /// </summary>
    public List<SpawnPoint> spawnPoints
    {
        get
        {
            //檢查清單是否沒被建立 or 已建立清單但內容物是空
            if(_spawnPoints == null || _spawnPoints.Count == 0)
            {
                _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
            }
            return _spawnPoints;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 清單內的生怪點全部執行生怪指令
    /// </summary>
    public void SpawnMonster()
    {
        //迴圈 : 重複限令生怪點依序產生
        for (int i = 0; i < spawnPoints.Count; i++) 
        { 
            spawnPoints[i].SpawnEffect();
        }
    }

}
