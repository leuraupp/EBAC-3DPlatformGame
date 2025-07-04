using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public MusicType musicType;
    public AudioSource audioSource;

    private void Start()
    {
        PlayMusic(musicType);
    }

    public void PlayMusic(MusicType musicType)
    {
        SoundManager.Instance.PlayMusic(musicType);
    }
}
