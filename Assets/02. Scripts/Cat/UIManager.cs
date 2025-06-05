using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public GameObject playObj;
        public GameObject introObj;
        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        public void OnStartButton()
        {
            bool isEmpty = inputField.text == "" ? true : false;

            if (isEmpty)
            {
                Debug.Log("이름을 입력해주세요.");
            }
            else
            {
                playObj.SetActive(true);
                introObj.SetActive(false);
                nameTextUI.text = inputField.text;
            }
        }
    }
}
