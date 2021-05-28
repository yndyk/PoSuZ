using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftGimmck : MonoBehaviour
{
    int counter = 0;
    float move = 0.01f;

    private void Update()
    {
        Vector3 p = new Vector3(move, 0, 0);
        transform.Translate(p);
        counter++;

        if (counter == 300)
        {
            counter = 0;
            move *= -1;
        }
    }
}
