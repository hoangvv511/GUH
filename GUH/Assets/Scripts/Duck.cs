using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{

    private Rigidbody2D myDuckR2;
    private Animator myDuckAnim;
    public Player player;
    public float lifeTime1 = 0.01f;

    // Use this for initialization
    void Start()
    {
        myDuckR2 = GetComponent<Rigidbody2D>();
        myDuckAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lifeTime1 <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            myDuckAnim.SetBool("Eat", true);
            lifeTime1 -= Time.deltaTime;


        }

    }
}
