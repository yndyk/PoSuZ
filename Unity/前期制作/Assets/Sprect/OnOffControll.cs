using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffControll : MonoBehaviour
{
    [SerializeField] GameObject Object;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q)) 
        {
            Object.SetActive(true);
        }
        else 
        {
            Object.SetActive(false);
        }
    } 
}
