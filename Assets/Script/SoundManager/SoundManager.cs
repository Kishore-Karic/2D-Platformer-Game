using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource SoundEffect;
    public AudioSource SoundMusic;

    public SoundType[] Sounds;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEffects(Sounds sound)
    {
        AudioClip clip = GetAudioClip(sound);
        if (clip != null)
        {
            SoundEffect.PlayOneShot(clip);
        }
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = GetAudioClip(sound);
        if(clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
    }

    public void StopMusic(Sounds sound)
    {
        AudioClip clip = GetAudioClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Stop();
        }
    }

    private AudioClip GetAudioClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        if(item != null)
        {
            return item.soundClip;
        } else
        {
            return null;
        }
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    BackGround,
    PlayerDeath,
    EnemyAttack,
    ButtonClick,
    ButtonCLickOkay,
    ButtonClickYes,
    ButtonClickNo,
    ButtonClickPlay,
    KeyPickUp
}
