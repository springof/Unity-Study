using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    public Rigidbody2D lamRb;

    public float h;

    void Update()
    {
        h = Input.GetAxis("Horizontal");

        // Transform 이동
        //transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;

        // Rigidbody 이동
        //lamRb.linearVelocityX = h * moveSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        lamRb.linearVelocityX = h * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter: " + collision.gameObject.name);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Stay: " + collision.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit: " + collision.gameObject.name);
    }
        //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider Enter: " + collision.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collider Stay: " + collision.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collider Exit: " + collision.gameObject.name);
    }
}
