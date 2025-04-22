using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    public void StartGame()
    {
        // Replace "GameScene" with your actual scene name
        SceneManager.LoadScene("Dev");
    }

    public void OpenOptions()
    {
        Debug.Log("Options button clicked - feature coming soon.");
        // Add options panel logic here
    }

    public void ShowCredits()
    {
        Debug.Log("Credits button clicked - show credits UI here.");
        // You can load a new scene or activate a credits UI panel
    }

    public void QuitGame()
    {
        Debug.Log("Quit button clicked - quitting game.");
        Application.Quit();

        // If in editor, stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
