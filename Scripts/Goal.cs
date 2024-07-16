using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;

    // When goal is triggered, call Player1Scored / Player2Scored
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!isPlayer1Goal)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Player1Scored();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Player2Scored();
            }
        }
    }
}
