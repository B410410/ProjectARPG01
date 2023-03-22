using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTPEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 傳送完畢後解鎖玩家操作
        DataSystem.ctrlLock = false;
    }
}
