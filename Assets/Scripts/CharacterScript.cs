using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    public Boolean facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
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
        //update the character's position
        transform.position = pos;
    }
}
