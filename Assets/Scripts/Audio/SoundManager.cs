using Ebac.Core.Singleton;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager> {
    public List<MusicData> musicDatas;
    public List<SFXData> sfxDatas;
    public AudioMixer audioMixer;

    public AudioSource audioSource;

    private MusicType currentMusicType;
    private bool isMute = false;

    public void PlayMusic(MusicType musicType)
    {
        MusicData musicData = GetMusicDatas(musicType);
        if (musicData != null && audioSource != null)
        {
            audioSource.clip = musicData.audioClip;
            audioSource.Play();
        }
        currentMusicType = musicType;
    }

    public MusicData GetMusicDatas(MusicType musicType) {
        return musicDatas.Find(m => m.musicType == musicType);
    }

    public void PlaySFX(SFXType sfxType)
    {
        SFXData sfxData = sfxDatas.Find(s => s.sfxType == sfxType);
        if (sfxData != null && audioSource != null)
        {
            audioSource.PlayOneShot(sfxData.audioClip);
        }
    }

    public SFXData GetSFXDatas(SFXType sfxType) {
        return sfxDatas.Find(m => m.sfxType == sfxType);
    }

    public void SetMute() {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0f : 1f;
    }
}

public enum MusicType
{
    TYPE_01,
    TYPE_02,
    TYPE_03
}

[System.Serializable]
public class MusicData
{
    public MusicType musicType;
    public AudioClip audioClip;
}

public enum SFXType {
    NONE,
    COIN,
    GUN,
    JUMP
}

[System.Serializable]
public class SFXData {
    public SFXType sfxType;
    public AudioClip audioClip;
}
