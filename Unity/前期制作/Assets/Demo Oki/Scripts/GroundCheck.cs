using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";
    public bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //設置判定を返すメソッド
    //物理判定の高新米に呼ぶ必要がある
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGround = true;
            Debug.Log("何かが判定に入りました");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            Debug.Log("何かが判定に入り続けています");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGround = false;
            Debug.Log("何かが判定をでました");

        }
    }
}
