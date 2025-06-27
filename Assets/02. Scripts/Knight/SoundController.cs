using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource eventAudio;

    [SerializeField] private AudioClip[] clips;

    [SerializeField] private Slider bgmVolume;
    [SerializeField] private Slider eventVolume;
    [SerializeField] private Toggle soundMute;

    private void Awake()
    {
        bgmVolume.value = bgmAudio.volume;
        eventVolume.value = eventAudio.volume;
        soundMute.isOn = bgmAudio.mute && eventAudio.mute;
    }

    private void Start()
    {
        BGMPlay("Town BGM");

        bgmVolume.onValueChanged.AddListener(OnBGMVolumeChanged);
        eventVolume.onValueChanged.AddListener(OnEventVolumeChanged);

        soundMute.onValueChanged.AddListener(OnMute);
    }

    public void BGMPlay(string clipName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
            {
                bgmAudio.clip = clip;
                bgmAudio.Play();

                return;
            }
        }
        Debug.Log($"{clipName}을 찾지 못했습니다.");
    }

    public void EventSoundPlay(string clipName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
            {
                eventAudio.PlayOneShot(clip);

                return;
            }
        }
        Debug.Log($"{clipName}을 찾지 못했습니다.");
    }

    public void OnBGMVolumeChanged(float volume)
    {
        bgmAudio.volume = volume;
    }

    public void OnEventVolumeChanged(float volume)
    {
        eventAudio.volume = volume;
    }

    public void OnMute(bool isMute)
    {
        bgmAudio.mute = isMute;
        eventAudio.mute = isMute;
    }
}

