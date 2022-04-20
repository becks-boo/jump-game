using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPoints : MonoBehaviour
{
    public int scoreToGive;
    private AudioSource paperAudio;
    private ScoreManager theScoreManager;

    private Rigidbody paperRb;

    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        paperRb =  GetComponent<Rigidbody>();
        // paperAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // paperAudio.PlayOneShot(collectSound, 1.0f);
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
        }
    }
}
