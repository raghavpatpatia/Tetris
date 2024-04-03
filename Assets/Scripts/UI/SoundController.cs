using UnityEngine;

public class SoundController
{
    private AudioSource soundEffect, backgroundMusic;
    private SoundType[] soundType;
    private EventService eventService;
    public SoundController(AudioSource soundEffect, AudioSource backgroundMusic, SoundType[] soundType, EventService eventService)
    {
        this.soundEffect = soundEffect;
        this.backgroundMusic = backgroundMusic;
        this.backgroundMusic.volume = 1f;
        this.soundType = soundType;
        this.eventService = eventService;
        SubscribeEvents();
    }
    private void SubscribeEvents()
    {
        eventService.PlaySoundEffect.AddListener(PlayMusic);
    }

    public void PlayBGMusic(Sounds sound)
    {
        AudioClip clip = GetAudioClip(sound);
        if (clip != null)
        {
            backgroundMusic.clip = clip;
            backgroundMusic.Play();
        }
        else
        {
            Debug.LogError(string.Format("{0}, Audio clip not found.", sound.ToString()));
        }
    }
    private void PlayMusic(Sounds sound)
    {
        AudioClip clip = GetAudioClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError(string.Format("{0}, Audio clip not found.", sound.ToString()));
        }
    }
    private AudioClip GetAudioClip(Sounds sound)
    {
        SoundType existingSound = System.Array.Find<SoundType>(soundType, item => item.soundType == sound);
        if (existingSound != null)
        {
            return existingSound.soundAudio;
        }
        return null;
    }

    ~SoundController()
    {
        eventService.PlaySoundEffect.RemoveListener(PlayMusic);
    }

}

[System.Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundAudio;
}

public enum Sounds
{
    BGMusic,
    ButtonClick,
    ScorePoints,
    LineClear
}