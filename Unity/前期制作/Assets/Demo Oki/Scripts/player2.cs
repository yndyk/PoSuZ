using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float inputSpeed;
    [Header("ジャンプ力")] public float jumpPower;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb2d;
    private float x_val;
    private float speed;
    #endregion

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        x_val = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("space"))
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }

        Vector3 left_SP = transform.position - Vector3.right * 0.3f;
        Vector3 right_SP = transform.position + Vector3.right * 0.3f;
        Vector3 EP = transform.position - Vector3.up * 0.1f;
        Debug.DrawLine(left_SP, EP);
        Debug.DrawLine(right_SP, EP);
    }

    private void FixedUpdate()
    {
        //待機
        if (x_val == 0)
        {
            speed = 0f;
        }
        //右に移動
        else if (x_val > 0)
        {
            speed = inputSpeed;
            transform.localScale = new Vector3(1, 1, 1);
        }
        //左に移動
        else if (x_val < 0)
        {
            speed = inputSpeed * -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //キャラクターを移動
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }
}
