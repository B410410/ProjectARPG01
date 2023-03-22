using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("�ͩǲ��ͪ��S��")]
    public GameObject spawnPointsEffect;
    [Header("�Ǫ�����")]
    public GameObject monsterObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// �Ǫ�����ͦ�
    /// </summary>
    public void SpawnMonster()
    {
        //��{�ƪ���:����A�y�СA����
        Instantiate(monsterObj, transform.position , transform.rotation);
    }

    /// <summary>
    /// �ͩǯS�Ĳ��ͥ\��(�������Ǫ�����ͦ�)
    /// </summary>
    public void SpawnEffect()
    {
        //��{�ƪ���:����A�y�СA����
        Instantiate(spawnPointsEffect, transform.position, transform.rotation);
        //������� SpawnMonster(1.5��)
        Invoke("SpawnMonster", 1.5f);
    }
}
