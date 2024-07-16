using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 startPosition;

    // Holds ball speed at start of round
    private float speed;

    // Start is called before first frame update
    void Start()
    {
        startPosition = transform.position;
        Launch();
    }

    // Start of game -- speed is retrieved and ball is sent to travel left or right, up or down
    private void Launch()
    {
        speed = GameSettings.GetStartingSpeed();
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    // Reset ball position, increase speed by Goal Speed Up
    public void ResetBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        speed += GameSettings.GetGoalSpeedUp();
        rb.velocity = new Vector2(speed * x, speed * y);
        transform.position = startPosition;
    }

    // After ball is hit, its speed increases for that round
    public void SpeedIncreaseAfterBounce()
    {
        rb.velocity = rb.velocity * GameSettings.GetBounceSpeedUp();
    }
}
