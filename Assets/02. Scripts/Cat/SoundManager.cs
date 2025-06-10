using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;

        public AudioClip introClip;
        public AudioClip bgmClip;

        public AudioClip jumpClip;
        public AudioClip colliderClip;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void SetBGMSound(string bgmName)
        {
            if (bgmName == "Intro")
                audioSource.clip = introClip;
            else if (bgmName == "Play")
                audioSource.clip = bgmClip;
            //
            audioSource.playOnAwake = true;
            audioSource.loop = true;
            audioSource.volume = 0.3f;

            audioSource.Play();
        }

        public void OnColliderSound()
        {
            audioSource.PlayOneShot(colliderClip);
        }

        public void OnJumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }
}
