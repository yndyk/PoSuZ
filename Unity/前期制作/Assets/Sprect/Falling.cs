using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
   public  bool FallFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       if(FallFlag == true) 
       {
            transform.Translate(0, -Time.deltaTime, 0);
            if (transform.position.y < -1.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (FallFlag == true)
        {
            transform.Translate(0, -Time.deltaTime, 0);
            if (collision.gameObject.tag == "Ground")
            {
                if (transform.position.y < -1.0f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        FallFlag = true;//ここでフラグが立つ
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (FallFlag == false)
        {
            transform.Translate(0, -Time.deltaTime, 0);
            if (collision.gameObject.tag == "Ground")
            {
                if (transform.position.y < -1.0f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
