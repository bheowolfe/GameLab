using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int NUM_BUGS = 10;
    [SerializeField] GameObject birdFood;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    { 
   
        int xMin = -12;
        int xMax = 12;
        int yMin = -5;
        int yMax = 5;

        for (int i = 0; i < NUM_BUGS; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(birdFood, position, Quaternion.identity);
        }
    }
}
