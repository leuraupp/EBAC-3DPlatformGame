using Ebac.Core.Singleton;
using System.Collections.Generic;
using UnityEngine;

public class SFXPool : Singleton<SFXPool> {
    private List<AudioSource> audioSources;

    public int poolSize = 10;

    private int currentIndex = 0;

    private void Start() {
        CreatePool();
    }

    private void CreatePool() {
        audioSources = new List<AudioSource>();

        for (int i = 0; i < poolSize; i++) {
            CreateAudioSourceItem();
        }
    }

    private void CreateAudioSourceItem() {
        GameObject go = new GameObject("SFXPool");
        go.transform.SetParent(transform);
        audioSources.Add(go.AddComponent<AudioSource>());
    }

    public void Play(SFXType sFXType) {
        if (sFXType == SFXType.NONE) {
            return;
        }
       var sfx = SoundManager.Instance.GetSFXDatas(sFXType);
        audioSources[currentIndex].clip = sfx.audioClip;
        audioSources[currentIndex].Play();

        currentIndex++;
        if (currentIndex >= audioSources.Count) {
            currentIndex = 0;
        }
    }
}
