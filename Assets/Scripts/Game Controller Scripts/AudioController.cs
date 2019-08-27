using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    private AudioSource audioSource;

    [Header("List of Music")]
    public AudioSource[] bgm;

    [Header("List of SFX")]
    public AudioSource[] sfx;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }
    public void PlaySFX(int soundToPlay)
    {
        if (soundToPlay < sfx.Length)
        {            
            sfx[soundToPlay].Play();
        }
    }

    public void PlayBGM(int musicToPlay)
    {
        if (!bgm[musicToPlay].isPlaying)
        {
            StopMusic();
            if (musicToPlay < bgm.Length)
            {
                bgm[musicToPlay].Play();
            }
        }
    }

    public void PlayBGMSlow(int musicToPlay)
    {
        bgm[musicToPlay].pitch = 0.5f;
        if (!bgm[musicToPlay].isPlaying)
        {
            if (musicToPlay < bgm.Length)
            {
                bgm[musicToPlay].Play();
            }
        }
    }

    public void PlayBGMNormal(int musicToPlay)
    {
        bgm[musicToPlay].pitch = 1f;
        if (!bgm[musicToPlay].isPlaying)
        {
            if (musicToPlay < bgm.Length)
            {
                bgm[musicToPlay].Play();
            }
        }
    }

    public void StopMusic()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
}
