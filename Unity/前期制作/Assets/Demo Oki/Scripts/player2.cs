﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float inputSpeed;
    [Header("ジャンプ力")] public float jumpPower;
    [Header("ジャンプを中断")]public float jumpThreshold;//ジャンプ中を判断
    [Header("攻撃ポイント")] public Transform attackPoint;
    [Header("攻撃範囲")] public float attackRadius;
    [Header("どれに攻撃するか")] public  LayerMask enemyLayer;
    [Header("ギミック対象")] public GameObject Gimmck;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb2d;
    private float x_val;
    private float speed;
    private float jumpup;
    public bool JumpFlag = false;
    private Animator animator;
    private bool isGround = true;
    private bool AttackFlag = false;
    private string state;// プレイヤーの状態管理
    private string prevState;// 前の状態を保存
    private int key = 0;//左右の入力管理
    #endregion

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent("Animator") as Animator;
        //Gimmck = GameObject.FindGameObjectsWithTag("lift");
    }

    private void Update()
    {
        x_val = Input.GetAxis("Horizontal");
        
        //ジェンプ
        if (JumpFlag == false)
        {
            if (Input.GetKeyDown("space"))
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                JumpFlag = true;
            }
        }
        
        jumpup = jumpPower;
        Debug.Log(jumpup);
        ChngeState();
        ChangeAnimation();
        animator.SetBool("attack",AttackFlag);

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
            animator.SetBool("run", false);
            key = 0;
        }
        //右に移動
        else if (x_val > 0)
        {
            speed = inputSpeed;
            transform.localScale = new Vector3(3, 3, 3);
            key = 1;
        }
        //左に移動
        else if (x_val < 0)
        {
            speed = inputSpeed * -1;
            transform.localScale = new Vector3(-3, 3, 3);
            key = -1;
        }
        //キャラクターを移動
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        //攻撃
        if (Input.GetKeyDown("up"))
        {
            Attack();
        }

    }
    //攻撃
    private void Attack()
    {
        AttackFlag = true;
        //animator.SetTrigger("attackTrigger");
        Debug.Log("攻撃");
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position,
                                                            attackRadius, enemyLayer);
        foreach (Collider2D hitEnemy in hitEnemys)
        {
            Debug.Log(hitEnemy.gameObject.name + "に攻撃");
            hitEnemy.GetComponent<EnemyManager>().OnDamage();
        }
        StartCoroutine("WaitForAttack");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    IEnumerator WaitForAttack() 
    {
        //攻撃スピードを変える
        yield return new WaitForSeconds(0.6f);
        AttackFlag = false;
    }

    //stateの状態遷移//
    private void ChngeState() 
    {
        //空中にいるかどうかを判定
        if (Mathf.Abs(rb2d.velocity.y) > jumpThreshold)
        {
            isGround = false;
        }
        if (isGround) 
        {
            if (key != 0)
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
            if (rb2d.velocity.y > 0)
            {
                state = "JUMP";
            }
            else if (rb2d.velocity.y < 0)
            {
                state = "FALL";
            }
        }
       Debug.Log(state);
    }

    //キャラのアニメーションを変更する
    private void ChangeAnimation()
    {
        if (prevState != state)
        {
            switch (state)
            {
                case "JUMP":
                    animator.SetBool("jump", true);
                    animator.SetBool("fall", false);
                    break;
                case "FALL":
                    animator.SetBool("fall", true);
                    animator.SetBool("jump", false);
                    break;
                case "IDLE":
                    animator.SetBool("run", false);
                    animator.SetBool("fall", false);
                    animator.SetBool("jump", false);
                    break;
                case "RUN":
                    animator.SetBool("run", true);
                    animator.SetBool("fall", false);
                    animator.SetBool("jump", false);
                    break;
                default:
                    animator.SetBool("run", false);
                    animator.SetBool("fall", false);
                    animator.SetBool("jump", false);
                   //animator.SetBool("attack", false);
                    break;
            }
            prevState = state;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpPower = 300;
        if (collision.gameObject.tag == "Ground")
        {
            if (!isGround)
            {
                isGround = true;
                JumpFlag = false;
            }
        }

        if (collision.gameObject.tag == "JumpUp")
        {
            jumpPower = 500;
            if (!isGround)
            {
                isGround = true;
                JumpFlag = false;
            }
        }
        //ギミック判定(ギミックの子オブジェクトになる)
        if (collision.gameObject.tag == "lift")
        {
            isGround = true;
            JumpFlag = false;
            transform.SetParent(Gimmck.transform);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (!isGround)
            {
                isGround = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //ギミック解除
        if (collision.gameObject.tag == "lift")
        {
            isGround = true;
            transform.SetParent(null);
        }
    }
}
