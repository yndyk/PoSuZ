using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChngColor : MonoBehaviour
{
    SpriteRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            mr.color = new Color(1.0f, 0.0f, 0.0f, 155.0f / 255.0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            mr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
