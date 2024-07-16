using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float speed;
    public bool isPlayer1;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public Vector3 scaleChange;
    // movement1 and movement2 take input from user and are assigned to movement
    private float movement;
    private float movement1;
    private float movement2;

    // At start of program, paddles are set
    void Start()
    {
        startPosition = transform.position;
        scaleChange = transform.localScale;
    }

    // Controls call THIS to move player 1 paddle
    void OnPlayer1Move(InputValue value)
    {
        movement1 = value.Get<float>();
    }

    // Controls call THIS to move player 1 paddle
    void OnPlayer2Move(InputValue value)
    {
        movement2 = value.Get<float>();
    }

    // Update is called once per frame (controls)
    void Update()
    {
        if (isPlayer1)
        {
            movement = movement1;
        }
        else
        {
            movement = movement2;
        }
    }

    // Take movement from controls and move paddle
    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    // After collision with paddle, ball speed may increase
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Ball>().SpeedIncreaseAfterBounce();
        }
    }

    // Paddle is reset and increased in size
    public void ResetPaddle()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        scaleChange.y += 0.1F;
        if (scaleChange.y < 3)
        {
            transform.localScale = scaleChange;
        }
    }
}
