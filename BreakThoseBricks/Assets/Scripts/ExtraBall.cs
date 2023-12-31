using UnityEngine;
using System.Collections;

public class ExtraBall : BasePowerUp
{

    //BallPrefab instantiated when the powerup is picked up
    public GameObject BallPrefab;

    //Make the min and max speed to be configurable in the editor.
    public float MinimumSpeed = 1;
    public float MaximumSpeed = 2;

    //To prevent the ball from keep bouncing horizontally we enforce a minimum vertical movement
    public float MinimumVerticalMovement = 0.5F;

    //Override of the OnPickup method of the base class  
    protected override void OnPickup()
    {
        //Call the default behaviour of the base class frist
        base.OnPickup();
        print("On pickup Call!");
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        print("Extra Collison");

        if (c.gameObject.tag == "Paddle")
        {
            print("Extra Collison Paddle");
            launchBall();
        }
    }

    public void launchBall()
    {
        //Get current speed and direction
        Vector2 direction = GetComponent<Rigidbody2D>().velocity;
        //float speed = 20f;
        float speed = direction.magnitude;
        direction.Normalize();

        //Make sure the ball never goes straight horizotal else it could never come down to the paddle.
        if (direction.x > -MinimumVerticalMovement && direction.x < MinimumVerticalMovement)
        {
            //Adjust the x, make sure it goes in a direction within the range limit set 
            direction.x = direction.x < 0 ? -MinimumVerticalMovement : MinimumVerticalMovement;

            //Adjust the y, make sure it keeps going into the direction it was going (up or down)
            direction.y = direction.y < 0 ? -1 + MinimumVerticalMovement : 1 - MinimumVerticalMovement;

            //Apply it back to the ball
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if (speed < MinimumSpeed || speed > MaximumSpeed)
        {
            //Limit the speed so it always above min en below max
            speed = Mathf.Clamp(speed, MinimumSpeed, MaximumSpeed);

            //Apply the limit
            //Note that we don't use * Time.deltaTime here since we set the velocity once, not every frame.
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

    }
}