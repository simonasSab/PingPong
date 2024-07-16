using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Called when a user clicks 'Play' button
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
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
