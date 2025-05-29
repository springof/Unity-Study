using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Untagged") == false)
        {
            int scoreTemp = 0;
            switch (collision.gameObject.tag)
            {
                case "Score1":
                    scoreTemp = 1;
                    break;
                case "Score2":
                    scoreTemp = 2;
                    break;
                case "Score3":
                    scoreTemp = 3;
                    break;
                case "Score10":
                    scoreTemp = 10;
                    break;
            }
            pinballManager.score += scoreTemp;
            Debug.Log($"Score increased to: {scoreTemp}");
        }

        //if (collision.gameObject.CompareTag("Score1"))
        //{
        //    pinballManager.score += 1;
        //    Debug.Log("Score increased to: 1");
        //}
        //else if (collision.gameObject.CompareTag("Score2"))
        //{
        //    pinballManager.score += 2;
        //    Debug.Log("Score increased to: 2");
        //}
        //else if (collision.gameObject.CompareTag("Score3"))
        //{
        //    pinballManager.score += 3;
        //    Debug.Log("Score increased to: 3");
        //}
        //else if (collision.gameObject.CompareTag("Score10"))
        //{
        //    pinballManager.score += 10;
        //    Debug.Log("Score increased to: 10");
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"Game Over! Final Score: {pinballManager.score}");
        }
    }
}
