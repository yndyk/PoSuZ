using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChng2 : MonoBehaviour
{

    public Fade fade;
    public bool fadeFlag;
    public float countTime = 0;

    // Start is called before the first frame update
    void Update()
    {
        if (fadeFlag == true)
        {
            countTime += Time.deltaTime;
        }

        if (countTime >= 3.0f)
        {
            fadeFlag = false;
            SceneManager.LoadScene("NextStage2");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fadeFlag = true;
        //ここの中身を変えると使用できる
        if (fadeFlag == true)
        {
            fade.FadeIn(0.5f, () => print("フェードイン完了"));
        }
    }
}
