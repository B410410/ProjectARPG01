using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;

[RequireComponent(typeof(AudioSource))]
public class BGMPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioSource audioSource
    {
        get
        {
            if (_audioSource == null) _audioSource = GetComponent<AudioSource>();
            return _audioSource;
        }
    }
    [Header("音樂清單")]
    public List<AudioClip> clips = new List<AudioClip>();

    private void Start()
    {
        DataSystem.SetBGMPlayer(this);
    }

    public void PlayMusic(int index)
    {
        audioSource.clip = clips[index];
        audioSource.Play();
    }

    public void SetBGMVol(float vol) 
    {
        audioSource.volume = vol;
    }
}
