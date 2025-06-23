using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetTile : MonoBehaviour
{
    public GameObject tilePrefab;
    public int rows = 5, cols = 5;

    public Button[] buttons;

    public static int turretIndex;

    private void Awake()
    {
        //buttons[0].onClick.AddListener(() => ChangeIndex(0));
        //buttons[1].onClick.AddListener(() => ChangeIndex(1));
        //buttons[2].onClick.AddListener(() => ChangeIndex(2));
        //buttons[3].onClick.AddListener(() => ChangeIndex(3));
        //buttons[4].onClick.AddListener(() => ChangeIndex(4));

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture the current index
            buttons[i].onClick.AddListener(() => ChangeIndex(index));
        }
    }

    IEnumerator Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                var pos = new Vector3(i, 0, j);

                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                Renderer renderer = tile.GetComponent<Renderer>();
                if ((i + j) % 2 == 0)
                {
                    renderer.material.color = Color.white;
                }
                else
                {
                    renderer.material.color = Color.black;
                }

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    void ChangeIndex(int index)
    {
        turretIndex = index;
    }
}
