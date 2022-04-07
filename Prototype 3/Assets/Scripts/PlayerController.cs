using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private static int jumpCount;
    private Vector3 originalGravity;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public float jumpForce = 5;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    
    void Start()
    {
        // <> gets the type of something, to find different things
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && jumpCount < 2)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            jumpCount += 1;
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver) 
        {
            isOnGround = true;
            dirtParticle.Play();
            jumpCount = 0;
        } 
        else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            jumpCount = 2;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
