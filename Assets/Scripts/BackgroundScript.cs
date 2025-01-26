using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the position of the background
        Vector2 pos = transform.position;

        //slowly move the background to the left
        pos.x -= 1f * Time.deltaTime;

        //when the background has went far enough to the left to the point they're offscreen
        if (pos.x < -33.8)
        {
            //put the background onto the right side, looping over the background
            pos.x = 31.2f;
        }

        //update the background's position
        transform.position = pos;
    }
}
