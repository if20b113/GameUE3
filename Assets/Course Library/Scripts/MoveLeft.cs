using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftRound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
        {
            if (playerControllerScript.dash)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (speed * 5));
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

        }


        if (transform.position.x < leftRound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
