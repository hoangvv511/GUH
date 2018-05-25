using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {

    public float speed_x = 0.05f, speed_y = 0.06f;

    public float time = 3f;

    private Vector3 move;

    private Animator anim;

    private float direct = 0;

    private int a = 0, b = 0, c = 0;

    private bool isRunJump = false;

    void Start () {
        move = transform.position;
        anim = GetComponent<Animator>();
        StartCoroutine(RunJump());
    }

    void FixedUpdate()
    {
        if(isRunJump)
            Move();
        Jump();
    }

    void Move()
    {
        move.x += speed_x * transform.localScale.x;
        transform.position = move;
    }

    void Jump()
    {
        move.y += speed_y*direct;
        transform.position = move;
    }

    IEnumerator RunJump()
    {
        yield return new WaitForSeconds(time);
        direct = 1;
        isRunJump = true;
        anim.SetBool("Jump", true);
        anim.SetBool("Fall", false);
        anim.SetBool("Stand", false);
        StartCoroutine(Fly());
    }

    IEnumerator Fly()
    {
        yield return new WaitForSeconds(0.5f);
        direct = 0.25f;
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.1f);
        direct = -1;
        anim.SetBool("Jump", false);
        anim.SetBool("Fall", true);
        anim.SetBool("Stand", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Vector3 temp = transform.localScale;
            if (temp.x == 1f)
            {
                temp.x = -1f;
            }
            else
            {
                temp.x = 1f;
            }
            transform.localScale = temp;
        }
        if (collision.tag == "Ground")
        {
            isRunJump = false;
            direct = 0;
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
            anim.SetBool("Stand", true);
            StartCoroutine(RunJump());
        }
    }
}
