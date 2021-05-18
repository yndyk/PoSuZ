using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEvent : MonoBehaviour
{
    [SerializeField] GameObject text;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("当たった");
        text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }

}
