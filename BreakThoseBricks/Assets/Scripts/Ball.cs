using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Paddle paddle;
    private bool gameStarted = false;
    private Vector3 paddleVector;

    // Start is called before the first frame update
    void Start()
    {
        //Set the ball on the paddle position
        paddleVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            this.transform.position = paddle.transform.position + paddleVector;
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked!");
                gameStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 2.5f);
            }
        }
    }
}
