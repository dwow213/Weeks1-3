using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    //variable for the curve used for bobbing up and down
    public AnimationCurve curve;
    //variable for evaluating the curve
    [Range(0, 2)] public float t;

    //boolean variable for determining of direction
    public Boolean facingRight = true;

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

        //if statements that determine whether the direction of the character
        //if the current mouse position is greater than the position of the character last frame
        if ((mousePos.x - pos.x) > 0)
        {
            //make them face right
            facingRight = true;
        }
        //if the current mouse position is less than the position of the character last frame
        else if ((mousePos.x - pos.x) < 0)
        {
            //make them face left
            facingRight = false;
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

        //update the character's position
        transform.position = pos;
    }
}
