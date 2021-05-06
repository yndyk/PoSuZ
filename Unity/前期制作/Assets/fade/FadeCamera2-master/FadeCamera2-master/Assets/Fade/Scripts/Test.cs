using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Fade fade;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            fade.FadeIn(0.5f, () => print("フェードイン完了"));
        }
        else if (Input.GetKeyDown(KeyCode.X)) 
        {
            fade.FadeOut(0.5f, () => print("フェードアウト完了"));
        }
    }
}
