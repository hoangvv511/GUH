﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_right : MonoBehaviour {
    private Vector3 move;

    public float speed = 0.05f;

    private Animator anim;

    private SpriteRenderer spriteR;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        move = transform.position;
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteR.sprite.name == "Boom8")
            Destroy(gameObject);
        Move();
    }

    void Move()
    {
        move.x += speed;
        transform.position = move;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.tag == "Wall" || collision.tag == "Ground")
        {
            anim.SetBool("Boom", true);
            speed = 0;
        }
    }
}