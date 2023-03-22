using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HitEffect : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioSource audioSource
    {
        get
        {
            if(_audioSource == null) _audioSource = GetComponent<AudioSource>();
            return _audioSource;
        }
    }
    [Header("­µ®ÄÀÉ")]
    public AudioClip clip;
    public float addDelay = 0.3f; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(clip);
        Destroy(gameObject, clip.length + addDelay);
    }

}
