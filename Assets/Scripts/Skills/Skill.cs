using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Skill : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioSource audioSource
    {
        get
        {
            if (_audioSource == null)
            {
                _audioSource = GetComponent<AudioSource>();
                if (_audioSource == null)
                {
                    _audioSource= gameObject.AddComponent<AudioSource>();
                }
                _audioSource.loop = loop;
            }
            return _audioSource;
        }
    }

    [Header("���g�t��")]
    public float flySpeed;

    [Header("�ޯ�ˮ`")]
    public float damage;

    [Header("�ޯ�v��")]
    public float health;

    [Header("�ޯ୵��")]
    public AudioClip clip;
    public bool loop;

    [Header("����B�涡�j(��)")]
    public float interval = 0.5f;

    [Header("����B��Ĳ�o����")]
    public int triggerCount = 1;

    [Header("�����S��")]
    public GameObject hitEffect;

    protected float setTime;
    /// <summary>
    /// �ޯ�O�_�٥i�H�@��
    /// </summary>
    protected bool isWorking
    {
        get
        {
            return triggerCount > 0 || !isTicTa;
        }
    }
    /// <summary>
    /// �ޯඡ�j�p��
    /// </summary>
    protected bool isTicTa
    {
        get
        {
            return Time.time - setTime > interval;
        }
    }
    protected bool isAction;

    // Start is called before the first frame update
    void Start()
    {
        setTime = Time.time;
        audioSource.clip= clip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeChecker();
        transform.Translate(Vector3.forward * flySpeed * Time.deltaTime);
        if(!isWorking) Invoke("Destroy", 1f);
    }

    /// <summary>
    /// �p�ɶ��j�O�_Ĳ�o���ˬd
    /// </summary>
    /// <returns>�O or �_</returns>
    public void TimeChecker()
    {
        if (isTicTa && isWorking ) 
        {
            isAction = true;
            setTime = Time.time; 
            triggerCount--; 
        }
        /*else
        {
            isAction = false;
        }*/
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// �ͦ������S�ĩ���w��H���W
    /// </summary>
    /// <param name="target">���w��H</param>
    /// <param name="offset">�y�Ъ������q</param>
    public void HitEffect(Transform target, Vector3 offset)
    {
        if(hitEffect) Instantiate(hitEffect, target.position + offset, target.rotation);
    }
}
