using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Nimmt die nächste Scene die im 'Build Settings' ist, siehe Index
        // In dem Fall Scene 'Prototype 3', das Spiel, somit ist es möglich im Nachhinein mehrere Scenes 
        // einzufügen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
