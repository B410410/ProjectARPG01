using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �����ƥ�Ĳ�o�t��
/// </summary>
public class StageEvent : MonoBehaviour
{
    [Header("�i�J�ƥ���榸��")]
    public int enterEventCount = 1;


    [Header("�i�JĲ�o�d��ƥ�")]
    public UnityEvent enterEvents;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //����Ĳ�o������\��
    private void OnTriggerEnter(Collider other)
    {
        //�a��Playe���Ҫ�����~��Ĳ�o
        if (other.tag == "Player")
        {
            Debug.Log("Player is coming");
            //����Ҧ��s�����\��
            if (enterEventCount > 0) 
            { 
                enterEvents.Invoke();
                enterEventCount--;
            } 
        }
    }
}
