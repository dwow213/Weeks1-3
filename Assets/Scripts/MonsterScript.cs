using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MonsterScript : MonoBehaviour
{
    //variable for the curve used for movement
    public AnimationCurve curve;
    //variable for evaluating the curve with a limit from 0 to 2
    [Range(0, 2)] public float t;

    //variable for the position of the mouse with a limit from -8 to 8 (basically the whole screen)
    [Range(-8, 8)] Vector2 mousePos;

    //variable for the initial mouse position (position last frame)
    Vector2 initialMousePos;

    //variables for the starting and ending position of the monster in for lerp
    public Transform start;
    public Transform end;

    //boolean variable for determining visibility
    public Boolean visible = true;

    //boolean variable for determining which side the monster is on
    public Boolean onLeftSide;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get the position of the mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //increment t based on the mouse position, which takes into account of t's limits
        t = mousePos.x / 8 + 1;

        //if statements that determines the visibility of the monster
        //if the current mouse x-position is greater than the x-position of the mouse last frame
        if ((mousePos.x - initialMousePos.x) > 0)
        {
            //if the monster is located on the left side
            if (onLeftSide)
            {
                //make monster visible
                visible = true;
            }
            //if the monster is located on the right side
            else
            {
                //make monster not visible
                visible = false;
            }

        }
        //if the current mouse x-position is less than the x-position of the mouse last frame
        else if ((mousePos.x - initialMousePos.x) < 0)
        {
            //if the monster is located on the left side
            if (onLeftSide)
            {
                //don't make monster visible
                visible = false;
            }
            //if the monster is located on the right side
            else
            {
                //make monster visible
                visible = true;
            }
        }

        //if the monster is visible
        if (visible)
        {
            //update their position using lerp and a curve evaluated by t
            transform.position = Vector2.Lerp(start.position, end.position, curve.Evaluate(t));
        }
        //if the monster is not visible
        else
        {
            //set their position to their beginning position, which is out of sight
            transform.position = start.position;
        }

        //update the initial mouse position in preparation for next frame
        initialMousePos = mousePos;
    }
}
