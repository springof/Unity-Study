using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen;
    public Button[] buttonUI;
    public VideoClip[] clips;
    private VideoPlayer videoPlayer;
    public bool isOn = false;
    public bool isMute = false;
    public int channel = 0;

    private void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0];
    }


    private void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnNextChannel);
        buttonUI[3].onClick.AddListener(OnPrevChannel);
    }

    public void OnScreenPower()
    {
        videoScreen.SetActive(!videoScreen.activeSelf);
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute);
    }

    public void OnNextChannel()
    {
        channel++;
        if (channel >= clips.Length)
        {
            channel = 0; // Wrap around to the first channel
        }
        videoPlayer.clip = clips[channel];
        videoPlayer.Play();
    }
    public void OnPrevChannel()
    {
        channel--;
        if (channel < 0)
        {
            channel = clips.Length - 1; // Wrap around to the last channel
        }
        videoPlayer.clip = clips[channel];
        videoPlayer.Play();
    }

}
