using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPirateSpawner : MonoBehaviour
{

    public GameObject prefab;
    public GameObject[] spawnedPirates = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        //for loop that will create 5 pop up pirates
        for (int i = 0; i < 5; i++)
        {
            spawnedPirates[i] = Instantiate(prefab, new Vector2(Random.Range(-8, 8), Random.Range(-5, 5)), transform.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
