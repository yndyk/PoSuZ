using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftManager : MonoBehaviour
{
    public GameObject RootgameObject;
    public bool RootFlag = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lift")
        {
            if (RootFlag == true)
            {
                this.gameObject.transform.parent = RootgameObject.gameObject.transform;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        RootFlag = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lift")
        {
            RootFlag = false;
            if (RootFlag == false)
            {
                this.gameObject.transform.parent = null;
            }
        }
    }
}
