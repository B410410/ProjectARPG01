using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPEvent : MonoBehaviour
{
    public GameObject pickupEffect;
    [Header("目的地的座標物件")]
    public Transform endPoint;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") 
        {
            //產生觸發特效
            Instantiate(pickupEffect, transform.position, transform.rotation);
            //紀錄傳送物件(玩家)
            target = other.transform;
            //鎖定玩家操作
            DataSystem.ctrlLock = true;
            //延遲0.5秒傳送
            Invoke("Teleport", 0.5f);
        }
    }

    /// <summary>
    /// 傳送(TP)
    /// </summary>
    void Teleport()
    {
        target.transform.position = endPoint.position;
    }
}
