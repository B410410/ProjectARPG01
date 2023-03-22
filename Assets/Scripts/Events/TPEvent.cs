using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPEvent : MonoBehaviour
{
    public GameObject pickupEffect;
    [Header("�ت��a���y�Ъ���")]
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
            //����Ĳ�o�S��
            Instantiate(pickupEffect, transform.position, transform.rotation);
            //�����ǰe����(���a)
            target = other.transform;
            //��w���a�ާ@
            DataSystem.ctrlLock = true;
            //����0.5��ǰe
            Invoke("Teleport", 0.5f);
        }
    }

    /// <summary>
    /// �ǰe(TP)
    /// </summary>
    void Teleport()
    {
        target.transform.position = endPoint.position;
    }
}
