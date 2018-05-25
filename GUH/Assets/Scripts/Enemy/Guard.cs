using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{

    public float speed = 0.05f;

    private Vector3 move;

    private bool isvertical;

    // Use this for initialization
    void Start()
    {
        move = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (transform.rotation.z == 0) //dưới đất hoặc ngược trên
        {
            //isvertical = false;
            move.x += speed * transform.localScale.x;
            transform.position = move;
            return;
        }
        else
        {
            //isvertical = true;
            move.y += speed * transform.localScale.x;
            transform.position = move;

        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Guard" || target.gameObject.tag == "Wall" || target.gameObject.tag == "Ground")
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
    
