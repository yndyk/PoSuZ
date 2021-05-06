using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandobark : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
