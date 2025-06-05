using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    public int count = 0;
    private void Start()
    {
        while (count <= 10)
        {
            count++;

            if (count % 3 == 0)
            {
                Debug.Log("박수 짝");
                continue;
            }
            else
            {
                Debug.Log(count);
            }

        }
    }
}
