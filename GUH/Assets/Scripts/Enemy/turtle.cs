using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle : MonoBehaviour
{
    //[SerializeField]
    //private Transform range;

    private bool collision, isvertical;

    public float speed = 0.05f;

    private Rigidbody2D myBody;

    private Vector3 move;

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        move = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (transform.rotation.z == 0) //dưới đất hoặc ngược trên
        {
            isvertical = false;
            move.x += speed * transform.localScale.x;
            transform.position = move;
            return;
        }
        else
        {
            if (transform.rotation.eulerAngles.z == 90) //dọc phải
            {
                move.y += speed * transform.localScale.x;
                isvertical = true;
                transform.position = move;
                return;
            }

            else // dọc trái
            {
                move.y += speed * transform.localScale.x * (-1f);
                isvertical = true;
                transform.position = move;
                return;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Range")
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