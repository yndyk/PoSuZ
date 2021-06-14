using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftGimmck : MonoBehaviour
{

    public int counter = 0;
    public float move = 0.01f;
    

    private void Update()
    {
         Vector3 p = new Vector3(move, 0, 0);
         transform.Translate(p);
         counter++;
         if (counter == 600)
         {
             counter = 0;
             move *= -1;
         }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(this.transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }

}
