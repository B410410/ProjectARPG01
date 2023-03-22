using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("生怪產生的特效")]
    public GameObject spawnPointsEffect;
    [Header("怪物物件")]
    public GameObject monsterObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// 怪物物件生成
    /// </summary>
    public void SpawnMonster()
    {
        //具現化物件:物件，座標，旋轉
        Instantiate(monsterObj, transform.position , transform.rotation);
    }

    /// <summary>
    /// 生怪特效產生功能(延遲執行怪物物件生成)
    /// </summary>
    public void SpawnEffect()
    {
        //具現化物件:物件，座標，旋轉
        Instantiate(spawnPointsEffect, transform.position, transform.rotation);
        //延後執行 SpawnMonster(1.5秒)
        Invoke("SpawnMonster", 1.5f);
    }
}
