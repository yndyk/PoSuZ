using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoll : MonoBehaviour
{
    public float speed;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent("Animator") as Animator;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");

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
        
    }

  
}
