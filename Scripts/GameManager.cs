using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Assigning GameObjects: Ball, Paddles and Goals
    [Header("Ball")]
    public GameObject ball;
    [Header("Player 1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;
    [Header("Player 2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    // Score counters for players 1 & 2
    [Header("Score UI")]
    public GameObject Player1Text;
    public GameObject Player2Text;

    // Message informs which player won
    public GameObject GameOverText;
    // Box for pause
    public GameObject pause;
    // Box for when one player has won
    public GameObject endgame;

    // When Player1Score or Player2Score reaches scoreLimit, game ends
    private int Player1Score;
    private int Player2Score;
    private int scoreLimit;

    // Start is called at start of program, Pause and Endgame are hidden
    void Start()
    {
        Time.timeScale = 1f;
        scoreLimit = GameSettings.GetScoreLimit();
        pause.SetActive(false);
        endgame.SetActive(false);
    }

    // Updates player 1 score, checks for score limit and calls ResetPosition()
    public void Player1Scored()
    {
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        if (Player1Score >= scoreLimit)
        {
            GameOver("Player 1 Wins!");
        }
        ResetPosition();
    }
    // Updates player 2 score, checks for score limit and calls ResetPosition()
    public void Player2Scored()
    {
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        if (Player2Score >= scoreLimit)
        {
            GameOver("Player 2 Wins!");
        }
        ResetPosition();
    }

    // Reset ball and paddles
    private void ResetPosition()
    {
        ball.GetComponent<Ball>().ResetBall();
        player1Paddle.GetComponent<Paddle>().ResetPaddle();
        player2Paddle.GetComponent<Paddle>().ResetPaddle();
    }

    // Sends message about player winning, activates Game Over box, pauses game time
    private void GameOver(string message)
    {
        GameOverText.GetComponent<TextMeshProUGUI>().text = message;
        endgame.SetActive(true);
        Time.timeScale = 0f;
    }

    // Start new game with same parameters, called when user clicks 'Play Again' button
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    // Button (ESC) calls Unity event which points to this script to pause/unpause game
    public void TogglePause(InputAction.CallbackContext context)
    {
        if (endgame.activeSelf)
        {
            return;
        }
        if (context.performed && Time.timeScale == 1f)
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (context.performed && Time.timeScale == 0f)
        {
            pause.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    // Called when a user clicks 'Exit to Menu' button
    public void ExitToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    // Called when a user clicks 'Quit' button
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
