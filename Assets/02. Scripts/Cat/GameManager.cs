using Cat;
using TMPro;
using UnityEngine;

namespace cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager;
        public TextMeshProUGUI playtimeUI;
        public TextMeshProUGUI scoreUI;

        private float timer;
        public static int score;
        public static bool isPlay;

        private void Start()
        {
            soundManager.SetBGMSound("Intro");
        }
        private void Update()
        {
            if (!isPlay) return;
            
            timer += Time.deltaTime;

            playtimeUI.text = $"플레이 시간 : {timer:F1}초";
            scoreUI.text = $"X {score}";
        }
    }
}

