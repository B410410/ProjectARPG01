using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 場景事件觸發系統
/// </summary>
public class StageEvent : MonoBehaviour
{
    [Header("進入事件執行次數")]
    public int enterEventCount = 1;


    [Header("進入觸發範圍事件")]
    public UnityEvent enterEvents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //內建觸發器執行功能
    private void OnTriggerEnter(Collider other)
    {
        //帶有Playe標籤的物件才能觸發
        if (other.tag == "Player")
        {
            Debug.Log("Player is coming");
            //執行所有連接的功能
            if (enterEventCount > 0) 
            { 
                enterEvents.Invoke();
                enterEventCount--;
            } 
        }
    }
}
