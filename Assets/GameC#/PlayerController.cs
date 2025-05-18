using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd;
    private Animator anim;
    private SpriteRenderer sr;
    private AttackArea attackArea;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashLenge;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();


    }

    void Move()
    {
        //入力
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //移動
        rd.velocity = new Vector2(x, y)*moveSpeed;

        //ダッシュ
        if (Input.GetKey(KeyCode.LeftShift))rd.velocity = rd.velocity * dashLenge;

        //アニメーション
        if (x > 0) sr.flipX = false;
        if (x < 0) sr.flipX = true;
        anim.SetFloat("Speed", Mathf.Abs(rd.velocity.x)+Mathf.Abs(rd.velocity.y));
    }
}
