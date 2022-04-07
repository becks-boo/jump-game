using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // private bool gameHasEnded = false;
    public float restartDelay = 2f;

    public void EndGame()
    {
        Debug.Log("GAME OVER!");

        Invoke("Restart", restartDelay);
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Physics.gravity = new Vector3(0, -9.8f, 0);
        // ScoreScript.scoreValue = 0;
    }
}
