using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaderScript : MonoBehaviour
{
    public float xSpeed = 10f;
    public float ySpeed = -1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.x += xSpeed * Time.deltaTime;

        Vector2 posInScreen = Camera.main.WorldToScreenPoint(pos);

        if (posInScreen.x > Screen.width)
        {
            pos.x = 8;
            xSpeed *= -1;
            pos.y += ySpeed;
        }


        if (posInScreen.x < -8)
        {
            pos.x = -8;
            xSpeed *= -1;
            pos.y += ySpeed;
        }

        if (posInScreen.y < -4)
        {
            pos.y = -4;
            ySpeed *= -1;
        }

        if (posInScreen.y > Screen.height)
        {
            pos.y = 4;
            ySpeed *= -1;
        }

        transform.position = pos;
    }
}
