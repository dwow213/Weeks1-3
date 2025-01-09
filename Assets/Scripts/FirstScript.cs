using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    float speed = 0.1F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed;

        Vector2 squareInScreenSpace = Camera.main.WorldToScreenPoint(pos);

        if (squareInScreenSpace.x < -8 || squareInScreenSpace.x > Screen.width)
        {
            speed *= -1;
        }

        transform.position = pos;
    }
}
