using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int maxHits;
    public int timesHit;

    // Start is called before the first frame update
    void Start()
    {
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("Ouch you hit me!");
        timesHit++;
        if (timesHit == maxHits)
        {
            print("Destroyed!");
            Destroy(gameObject);
        }
    }
}
