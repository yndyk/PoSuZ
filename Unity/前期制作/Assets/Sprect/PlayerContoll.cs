using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoll : MonoBehaviour
{
    public float speed;
    Animator animator;
    public float flap = 100f;
    Rigidbody2D rd2D;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent("Animator") as Animator;
        rd2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");

        //移動
        if( Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0, 0);
            animator.SetBool("warposwoik", true);
        }
        else
        {
            animator.SetBool("warposwoik", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0, 0);
            animator.SetBool("warposwoik", true);
        }
        //攻撃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Attack", true);
        }
        else 
        {
            animator.SetBool("Attack", false);
        }
        //ジャンプ
        if (Input.GetKeyDown("j")) 
        {
            rd2D.AddForce(Vector2.up * flap);
            animator.SetBool("Jump", true);
        }
        else 
        {
            animator.SetBool("Jump", false);
        }
    }

  
}
