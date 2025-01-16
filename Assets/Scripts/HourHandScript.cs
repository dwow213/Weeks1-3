using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourHandScript : MonoBehaviour
{
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z -= speed;
        transform.eulerAngles = rotation;
    }
}
