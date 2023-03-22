using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterManager : MonoBehaviour
{
    /// <summary>
    /// �ͩ��I�M������Ʀ�m
    /// </summary>
    private List<SpawnPoint> _spawnPoints;
    /// <summary>
    /// �ͩ��I�M�檺��~���f
    /// </summary>
    public List<SpawnPoint> spawnPoints
    {
        get
        {
            //�ˬd�M��O�_�S�Q�إ� or �w�إ߲M������e���O��
            if(_spawnPoints == null || _spawnPoints.Count == 0)
            {
                _spawnPoints = new List<SpawnPoint>(GetComponentsInChildren<SpawnPoint>());
            }
            return _spawnPoints;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// �M�椺���ͩ��I��������ͩǫ��O
    /// </summary>
    public void SpawnMonster()
    {
        //�j�� : ���ƭ��O�ͩ��I�̧ǲ���
        for (int i = 0; i < spawnPoints.Count; i++) 
        { 
            spawnPoints[i].SpawnEffect();
        }
    }

}
