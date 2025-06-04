using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource audioSource;
        public AudioClip jumpClip;
        public AudioClip bgmClip;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }

        public void SetBGMSound()
        {
            audioSource.clip = bgmClip;
            audioSource.playOnAwake = true;
            audioSource.loop = true;
            audioSource.volume = 0.5f;

            audioSource.Play();
        }
    }
}
