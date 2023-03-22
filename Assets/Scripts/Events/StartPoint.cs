using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [Header("���a����")]
    public GameObject playerObj;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        DataSystem.StageMusicPlay();
    }

    /// <summary>
    /// ���a����ͦ�
    /// </summary>
    public void SpawnPlayer()
    {
        //�q���t�Ϊ�l�w��
        //DataSystem.playerPos = transform.position;
        //��{�ƪ���:����A�y�СA����
        Instantiate(playerObj, transform.position, transform.rotation);
    }
}
