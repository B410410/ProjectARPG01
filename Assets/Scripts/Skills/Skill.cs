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

    [Header("飛射速度")]
    public float flySpeed;

    [Header("技能傷害")]
    public float damage;

    [Header("技能治療")]
    public float health;

    [Header("技能音效")]
    public AudioClip clip;
    public bool loop;

    [Header("持續運行間隔(秒)")]
    public float interval = 0.5f;

    [Header("持續運行觸發次數")]
    public int triggerCount = 1;

    [Header("擊中特效")]
    public GameObject hitEffect;

    protected float setTime;
    /// <summary>
    /// 技能是否還可以作用
    /// </summary>
    protected bool isWorking
    {
        get
        {
            return triggerCount > 0 || !isTicTa;
        }
    }
    /// <summary>
    /// 技能間隔計時
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
    /// 計時間隔是否觸發的檢查
    /// </summary>
    /// <returns>是 or 否</returns>
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
    /// 生成打擊特效於指定對象身上
    /// </summary>
    /// <param name="target">指定對象</param>
    /// <param name="offset">座標的偏移量</param>
    public void HitEffect(Transform target, Vector3 offset)
    {
        if(hitEffect) Instantiate(hitEffect, target.position + offset, target.rotation);
    }
}
