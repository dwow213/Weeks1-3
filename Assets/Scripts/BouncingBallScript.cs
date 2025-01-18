using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class BouncingBallScript : MonoBehaviour
{
    public float xSpeed = 5f;
    public float ySpeed = 5f;
    public float xSpeedDirection = 1f;
    public float ySpeedDirection = 1f;
    public float size = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the position of the object
        Vector2 pos = transform.position;

        //changes speed by pressing left/right arrow keys or a/d
        xSpeed += Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        ySpeed += Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        //changes size by pressing up/down arrow keys or s/w
        size += Input.GetAxisRaw("Vertical") * Time.deltaTime;

        //change position
        pos.x += xSpeed * xSpeedDirection * Time.deltaTime;
        pos.y += ySpeed * ySpeedDirection * Time.deltaTime;

        //translate the position of the object in the world to the screen
        Vector2 posInScreen = Camera.main.WorldToScreenPoint(pos);

        //bounce the ball off of the edge
        if (posInScreen.x > Screen.width)
        {
            //pos.x = Screen.width;
            xSpeedDirection *= -1;
        }

        if (posInScreen.x < -8)
        {
            //pos.x = -8;
            xSpeedDirection *= -1;
        }

        if (posInScreen.y > Screen.height) 
        {
            //pos.y = Screen.height - 1;
            ySpeedDirection *= -1;
        }

        if (posInScreen.y < -5)
        {
            //pos.y = -4;
            ySpeedDirection *= -1;
        }

        //reset position and speed
        if (Input.GetKeyDown("space"))
        {
            pos.x = 0;
            pos.y = 0;
            xSpeed = UnityEngine.Random.Range(1f, 20f);
            ySpeed = UnityEngine.Random.Range(1f, 20f);
        }

        //update position and size of transformation
        transform.position = pos;
        transform.localScale = new Vector2(size, size);
    }
}
