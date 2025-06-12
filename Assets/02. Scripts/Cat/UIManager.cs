using cat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public GameObject playObj;
        public GameObject playUI;
        public GameObject introObj;
        public GameObject videoPanel;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;
        public Button reStartButton;

        private void Awake()
        {
            playObj.SetActive(false);
            playUI.SetActive(false);
            introObj.SetActive(true);         
        }

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButton);
            reStartButton.onClick.AddListener(OnRestartButton);
        }
        

        public void OnStartButton()
        {
            bool isEmpty = inputField.text == "" ? true : false;

            if (isEmpty)
            {
                Debug.Log("이름을 입력해주세요.");
            }
            else
            {
                GameManager.isPlay = true;

                playObj.SetActive(true);
                playUI.SetActive(true);
                introObj.SetActive(false);
                nameTextUI.text = inputField.text;
                soundManager.SetBGMSound("Play");
            }
        }
        public void OnRestartButton()
        {
            GameManager.ResetPlayUI();
            playObj.SetActive(true);
            videoPanel.SetActive(false);
            soundManager.SetBGMSound("Play");
        }
    }
}
