using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickShotScript : MonoBehaviour
{
    
    //variables for speed
    public float xSpeed = 10;
    public float ySpeed = 0;

    //variable for direction of speed and rotation
    public float direction = 1;

    //variables for animation curves
    [Range(0, 1)] public float t = 0;
    public AnimationCurve movementCurve;
    public AnimationCurve rotationCurve;


    //variable for whether square is jumping
    bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the position of the object
        Vector2 pos = transform.position;

        Quaternion rot = transform.rotation;

        //change position with speed and delta time
        pos.x += direction * xSpeed * Time.deltaTime;

        //translate the position of the object in the world to the screen
        Vector2 posInScreen = Camera.main.WorldToScreenPoint(pos);

        //bounce the square of the sides when it hits it
        if (posInScreen.x > Screen.width || posInScreen.x < -8.5)
        {

            direction *= -1;
        }

        //checks if spacebar was pressed and if square is not already jumping
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            //starts jumping process
            jumping = true;
        }

        //the process of jumping
        if (jumping)
        {
            //increment t for the curve and timer
            t += 0.01f;

            //change the position of y based on the movement curve and value of t
            pos.y += ySpeed * movementCurve.Evaluate(t) * Time.deltaTime;

            //change the rotation of the square based on the rotation curve and value of t
            rot.z += -direction * 50 * rotationCurve.Evaluate(t) * Time.deltaTime;

            //when timer is finished (t == 1) as well as the curve
            if (t >= 1)
            {
                //deactivate the jumping process
                jumping = false;
                //reset t
                t = 0;
                //reset position.y to its inital state
                pos.y = 0.01f;
                rot.z = 0;
            }
        }

        //update the position of the square
        transform.position = pos;
        transform.rotation = rot;
    }
}
