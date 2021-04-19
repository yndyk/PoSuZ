using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerContoll : MonoBehaviour
{
    Rigidbody2D rd2D;
    Animator animator;

    public float speed;//移動スピード
    public float speedThreshold = 2.0f;//移動中を判断
    public float speedForce = 30.0f;//移動始めに加算する力

    public float flap = 100f;//ジャンプの力
    public float jumpThreshold = 2.0f;//ジャンプ中を判断
 
    bool isGround = true;//地面と接しているか
    int key = 0;//左右の入力管理

    public enum JumpNonber 
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4
    }

    string state;// プレイヤーの状態管理
    string prevState;// 前の状態を保存
    float stateEffect = 1; // 状態に応じて横移動速度を変えるための係数

    void Start()
    {
        animator = GetComponent("Animator") as Animator;
        rd2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        {
            /* 
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
             if (Input.GetKeyDown(KeyCode.UpArrow))
             {
                 rd2D.AddForce(Vector2.up * flap);
                 animator.SetInteger("Jump A ああ", (int)JumpNonber.A);
             }
             */
        }
        GetInputKey();
        //ChngeState();
        Mode();
       
    }

    void GetInputKey() 
    {
        key = 0;
        float dx = Input.GetAxis("Horizontal")*speed;
        transform.Translate(dx, 0.0f, 0.0f);
        if (dx <= 0)
        {
            key = 1;
        }
        if (dx > 0)
        {
            key = -1;
        }
    }

    void ChngeState() 
    {
        if(Mathf.Abs(rd2D.velocity.y) > jumpThreshold) 
        {
            isGround = false;
        }

        if (isGround) 
        {
            if(key != 0)
            {
                state = "RUN";
            }
            else 
            {
                state = "IDLE";
            }
        }
        else 
        {
            if(rd2D.velocity.y > 0) 
            {
                state = "JUMP";
            }
            else if(rd2D.velocity.y < 0) 
            {
                state = "FALL";
            }
        }
    }
    
    void Mode ()
    {
        
        //ジャンプ処理
        if (isGround)
        {
            float dy = Input.GetAxis("Jump")*flap;
            rd2D.AddForce(Vector2.up * dy);
            //isGround = false;
            Debug.Log(isGround);
        }

        float speedX = Mathf.Abs(this.rd2D.velocity.x);
        if (speedX < this.speedThreshold)
        {
            this.rd2D.AddForce(transform.right*key*this.speedForce*stateEffect);
        }
        else 
        {
            this.transform.position += new Vector3(speed * Time.deltaTime * key * stateEffect,0.0f,0.0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") 
        {
            if (!isGround) 
            {
                isGround = true;
            }
        }
        animator.SetInteger("Jump A ああ", (int)JumpNonber.E);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground") 
        {
            if (!isGround)
            {
                isGround = true;
            }
        }
    }
}
