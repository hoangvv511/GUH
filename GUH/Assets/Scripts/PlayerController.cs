using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 8f;
    public float maxVerlocity = 4f;

    [SerializeField]
    private Rigidbody2D mybody;
    private Animator animator;
    // Use this for initialization
    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveControl();
    }

    void MoveControl()
    {
        float forxeX = 0f;
        float forxeY = 0f;
        float vel = Mathf.Abs(mybody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            if (vel < maxVerlocity)
            {
                forxeX = speed;
            }
            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;
            animator.SetBool("Walk", true);

            mybody.AddForce(new Vector2(forxeX, 0));

        }
        else if (h < 0)
        {
            if (vel < maxVerlocity)
                forxeX = -speed;

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;
            animator.SetBool("Walk", true);

            mybody.AddForce(new Vector2(forxeX, 0));
        }
        else
        {
            animator.SetBool("Walk", false);
            mybody.AddForce(new Vector2(forxeX, 0));

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            forxeX = 0;
            forxeY = 5;
            mybody.velocity = new Vector2(forxeX, forxeY * mybody.gravityScale);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            mybody.gravityScale = mybody.gravityScale * -1;
            Vector3 Scale;
            Scale = transform.localScale;
            Scale.y *= -1;
            transform.localScale = Scale;

        }

    }
}
