using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //variable for the curve used for bobbing up and down
    public AnimationCurve curve;
    //variable for evaluating the curve
    [Range(0, 2)] public float t;

    //variable that holds the initial scale of the light objects before it is changed
    Vector2 trueScale;

    // Start is called before the first frame update
    void Start()
    {
        //get the scale of the objects before any changes were made
        trueScale = transform.localScale;

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

        //set the size of the object to its initial state before changes
        Vector2 size = trueScale;

        //set the character's x-position to the mouse's x-position
        pos.x = mousePos.x + 1.1f;

        //randomize the size of the object
        size.x += Random.Range(-0.1f, 0.1f);
        size.y += Random.Range(-0.1f, 0.1f);

        //increment t for the curve
        t += 1f * Time.deltaTime;
        //bob the character up and down by changing its y-position using the curve and t
        pos.y = curve.Evaluate(t);

        //check if light's x-position goes past its limit on both sides
        //if it does, stop it in place 
        if (pos.x > 7.5)
        {
            pos.x = 7.5f;
        }

        if (pos.x < -5.3)
        {
            pos.x = -5.3f;
        }

        //if t reaches its limit (2), reset it to 0 to loop the curve
        if (t >= 2)
        {
            t = 0;
        }

        //update the character's position and size
        transform.position = pos;
        transform.localScale = size;

    }
}
