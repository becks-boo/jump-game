using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private ScoreManager theScoreManager;
    public float restartDelay = 3f;

    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void EndGame()
    {
        theScoreManager.scoreIncreasing = false;

        Debug.Log("GAME OVER!");
        Invoke("Restart", restartDelay);

        theScoreManager.scoreCount = 0;
        
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Physics.gravity = new Vector3(0, -9.8f, 0);
        theScoreManager.scoreIncreasing = true;
    }
}
