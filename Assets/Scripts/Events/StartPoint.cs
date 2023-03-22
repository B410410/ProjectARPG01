using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [Header("玩家物件")]
    public GameObject playerObj;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        DataSystem.StageMusicPlay();
    }

    /// <summary>
    /// 玩家物件生成
    /// </summary>
    public void SpawnPlayer()
    {
        //通報系統初始定位
        //DataSystem.playerPos = transform.position;
        //具現化物件:物件，座標，旋轉
        Instantiate(playerObj, transform.position, transform.rotation);
    }
}
