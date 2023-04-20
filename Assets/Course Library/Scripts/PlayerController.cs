using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce;
    public float gravtiyModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;  
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private int jumpcount = 2;
    public bool dash = false;
 
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravtiyModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && jumpcount < 2 )
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerAnim.SetTrigger("Jump_trig");
            jumpcount++;
            dirtParticle.Stop();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        { 
            dash = true;
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
            Debug.Log("Dash");
        }
        else if(dash)
        {
            dash = false;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
            jumpcount = 0;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            if(gameOver == false)
            {
                gameOver = true;
                dirtParticle.Stop();
                explosionParticle.Play();
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                playerAudio.PlayOneShot(crashSound, 1.0f);
                Debug.Log("Game Over!");
            }
        }
    }
}
