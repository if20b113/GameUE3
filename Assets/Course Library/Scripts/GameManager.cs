using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float score;
    private PlayerController playerControllerScript;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
        scoreText.text = "Score: " + score;
        gameOverText.gameObject.SetActive(false);
    }

    // Udgfgdfdfgpdate is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            if (playerControllerScript.dash)
            {
                score += 2;
            }
            else
            {
                score++;
            }
            Debug.Log("Score: " + score);

            scoreText.text = "Score: " + score;
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
        }

    }
}
