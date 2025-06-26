using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class KnightController_Joystick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();

        //jumpButton.onClick.AddListener(Jump);
        //atkButton.onClick.AddListener(Attack);
    }

    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized;

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);
    }

    void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            knightRb.linearVelocity = inputDir * moveSpeed;
        }
    }
}
