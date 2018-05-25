using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D myRigibody;
    [SerializeField]
    private float movementSpeed;
    private bool facingRight;
    private Animator myAnimator;
    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;
    public float rotate;

    private bool isGrounded2;
    private bool isReverse;
    private bool jump;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool airControl;

    public float horizontal;
    public bool isPressJump;
    public bool isPressChangeGravity;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        facingRight = true;
        myRigibody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        //horizontal = Input.GetAxis("Horizontal");
        Move(horizontal);
        isGrounded = IsGrounded();

        HandleMovement(horizontal);
        Flip(horizontal);
        HandleLayer();
        ResetValue();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("flag1"))
        {
            gameObject.GetComponent<CompleteController>().ShowTheMenu();
            //if (score >= scoremap1)
            //{
            //    scoremap1 = score;
            //    PlayerPrefs.SetInt("scoremap1", scoremap1);

            //    highscore = scoremap1;
            //    PlayerPrefs.SetInt("highscore", highscore);
            //}
        }
    }

    public void Move(float input)
    {
        horizontal = input;
    }

    public void Jumping(bool jump)
    {
        isPressJump = jump;
    }

    public void ChangeGravity(bool isChange)
    {
        isPressChangeGravity = isChange;
    }

    private void HandleMovement(float horizontal)
    {
        if (myRigibody.velocity.y < 0)
        {
            myAnimator.SetBool("Up", true);
        }

        if (myRigibody.gravityScale < 0)
        {
            myAnimator.SetBool("Up", false);
            if (myRigibody.velocity.y > 0)
            {
                myAnimator.SetBool("Up", true);
            }
            if (isGrounded && jump)
            {
                isGrounded = false;
                myRigibody.AddForce(new Vector2(0, -jumpForce));
                myAnimator.SetTrigger("Jump");
            }
        }


        //if(isGrounded || airControl)
        //{
        //    myRigibody.velocity = new Vector2(horizontal * movementSpeed, myRigibody.velocity.y);
        //}

        myRigibody.velocity = new Vector2(horizontal * movementSpeed, myRigibody.velocity.y); //  x=-1; y= 0
        if (myRigibody.gravityScale > 0)
        {
            if (isGrounded && jump)
            {
                isGrounded = false;
                myRigibody.AddForce(new Vector2(0, jumpForce));
                myAnimator.SetTrigger("Jump");

            }
        }
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private void HandleInput()
    {
       
        if(Input.GetKeyDown(KeyCode.G))
        {
            //transform.Rotate(0, 90, 0);
            GetComponent<SpriteRenderer>().enabled = false;


        }
        if (Input.GetKeyDown(KeyCode.F))
        {   
            //transform.Rotate(0, 90, 0);
            GetComponent<SpriteRenderer>().enabled = true;


        }

        if (isPressJump == true)
        {
            jump = true;            
        }

        if (isPressChangeGravity == true)
        {
            if (isReverse)
            {
                //jump = true;
                myRigibody.gravityScale = myRigibody.gravityScale * -1;
                Vector3 Scale;
                Scale = transform.localScale;
                Scale.y *= -1;
                transform.localScale = Scale;
                /////

                if (myRigibody.gravityScale < 0)
                {
                    isGrounded = false;
                    myAnimator.SetTrigger("Jump");

                }
            }
            isReverse = false;

        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }

    private void ResetValue()
    {
        jump = false;
    }

    private bool IsGrounded()
    {
        if (myRigibody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        myAnimator.ResetTrigger("Jump");
                        myAnimator.SetBool("Up", false);
                        isReverse = true;
                        return true;

                    }
                }
            }
        }
        return false;
    }


    private void HandleLayer()
    {
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
}
