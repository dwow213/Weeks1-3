using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    //variable that holds the initial scale of the light objects before it is changed
    Vector2 trueScale;

    // Start is called before the first frame update
    void Start()
    {
        //get the scale of the objects before any changes were made
        trueScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //get the position of the character
        Vector2 pos = transform.position;
        //get the position of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //set the size of the object to its initial state before changes
        Vector2 size = trueScale;

        //set the character's x-position to the mouse's x-position
        pos.x = mousePos.x + 3;

        //randomize the size of the object
        size.x += Random.Range(-0.1f, 0.1f);
        size.y += Random.Range(-0.1f, 0.1f);

        //check if light's x-position goes past its limit on both sides
        //if it does, stop it in place 
        if (pos.x > 9.4)
        {
            pos.x = 9.4f;
        }

        if (pos.x < -3.4)
        {
            pos.x = -3.4f;
        }

        //update the character's position and size
        transform.position = pos;
        transform.localScale = size;
    }
}
