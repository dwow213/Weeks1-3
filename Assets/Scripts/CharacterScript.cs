using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    //variable for the curve used for bobbing up and down
    public AnimationCurve curve;
    //variable for evaluating the curve with a limit from 0 to 2
    [Range(0, 2)] public float t;

    //variable for the initial mouse position (position last frame)
    Vector2 initialMousePos;

    //boolean variable for determining visibility of character
    public Boolean visible = true;
    //boolean variable for determining the direction the sprite is facing
    public Boolean facingRight;

    // Start is called before the first frame update
    void Start()
    {
        //set t to 0
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //get the position of the character
        Vector2 pos = transform.position;
        //get the position of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if statements that determines the visibilty of the character
        //if the current mouse x-position is greater than the x-position of the mouse last frame
        if ((mousePos.x - initialMousePos.x) > 0)
        {
            //if the sprite is supposed to be facing right
            if (facingRight)
            {
                //make them visible
                visible = true;
            }
            //if the sprite is supposed to be facing left
            else
            {
                //don't make them visible
                visible = false;
            }

        }
        //if the current mouse x-position is less than the x-position of the mouse last frame
        else if ((mousePos.x - initialMousePos.x) < 0)
        {
            //if the sprite is supposed to be facing right
            if (facingRight)
            {
                //don't make them visible
                visible = false;
            }
            //if the sprite is supposed to be facing left
            else
            {
                //make them visible
                visible = true;
            }

        }

        //set the character's x-position to the mouse's x-position
        pos.x = mousePos.x;

        //increment t for the curve
        t += 1f * Time.deltaTime;
        //bob the character up and down by changing its y-position using the curve and t
        pos.y = curve.Evaluate(t);

        //check if the character's x-position goes past its limit on both sides
        //if it does, stop it in place 
        if (pos.x > 6.4)
        {
            pos.x = 6.4f;
        }

        if (pos.x < -6.4)
        {
            pos.x = -6.4f;
        }

        //if t reaches its limit (2), reset it to 0 to loop the curve
        if (t >= 2)
        {
            t = 0;
        }

        //if the character is not visible
        if (!visible)
        {
            //set the character's x-position to be off-screen
            pos.x = -20;
        }

        //update the character's position
        transform.position = pos;

        //update the initial mouse position in preparation for next frame
        initialMousePos = mousePos;
    }
}
