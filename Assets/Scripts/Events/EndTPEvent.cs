using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTPEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �ǰe��������ꪱ�a�ާ@
        DataSystem.ctrlLock = false;
    }
}
