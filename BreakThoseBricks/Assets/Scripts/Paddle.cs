using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        print("This is my first Unity script!");
    }

    // Update is called once per frame
    void Update()
    {
        //Set variable for current position
        //Vector3 paddlePos = new Vector3(0f, this.transform.position.y, 0f);

        //Get mouse position
        //float mousePos = Convert.ToInt32(Input.mousePosition.x / Screen.width * 0.5);
        //float mousePos = Input.mousePosition.x / 200;

        //Set new mouse X position
        //paddlePos.x = Mathf.Clamp(mousePos, 0f, 100f);
        //paddlePos.x = mousePos;

        //Change paddle to match new X position
        //this.transform.position = paddlePos;

        this.transform.position = new Vector3(Input.mousePosition.x / Screen.width * 8 - 4, this.transform.position.y, 0f);
    }
}
