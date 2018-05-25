using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Union : MonoBehaviour {

    [SerializeField]
    private Transform startPos, endPos;

    private bool collision, isStand;

    public float speed = -0.05f;

    private Rigidbody2D myBody;

    private Vector3 move;

    private Animator anim;

    private SpriteRenderer spriteR;

    // Use this for initialization
    void Start()
    {
        move = transform.position;
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    void ChangeDirection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));

        Debug.DrawLine(startPos.position, endPos.position, Color.green);

        if (!collision)
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player.move.x >= move.x - 3f && Player.move.x <= move.x + 3f)
        {
            anim.SetBool("GrowUp", true);
        }
        if (spriteR.sprite.name == "Union4")
        {
            isStand = true;
            anim.SetBool("Walk", true);
        }
        if (isStand)
        {
            Move();
            ChangeDirection();
        }
    }

    void Move()
    {
        move.x += speed * transform.localScale.x;
        transform.position = move;
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
    }
}
