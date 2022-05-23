using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{

    public void LoadLevel(int level)
    {
        // Load the game.
        Debug.Log("Playing...");
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        // Quit the game.
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
