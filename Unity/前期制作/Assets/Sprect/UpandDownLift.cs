using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpandDownLift : MonoBehaviour
{
    public int counter = 0;
    public float move = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = new Vector3(0, move, 0);
        transform.Translate(p);
        counter++;
        if (counter == 600)
        {
            counter = 0;
            move *= -1;
        }
    }
}
