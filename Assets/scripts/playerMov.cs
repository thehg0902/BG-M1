using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{

    // movment
    private float moveInput;
    private Rigidbody2D rb2d;


    private bool faceRight = true;
    private bool isMoving = false;

    public float gravity;
    [SerializeField]  float speed;
    [SerializeField]  float jumpForce;


    //ground check
    [SerializeField]  private float checkRadius = 2f;
    [SerializeField]  private Transform groundCheck;
    private bool grounded = false;
    public LayerMask whatIsgGround;

    //feet and head colliders
    public CapsuleCollider2D myHead;
    public BoxCollider2D myFeet;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }



     void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsgGround);

        //facing
        faceDirection();
        //ad movement
        moveInput = Input.GetAxis("Horizontal");
        //jumping 


    }//end Fixupdate



     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            Debug.Log("hop");
            rb2d.velocity = Vector2.up * jumpForce;
        }
        //move with combined velocity
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y - gravity * Time.deltaTime);

    }//end update


    public void faceDirection()
    {
        if(moveInput > 0)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            faceRight = true;
            
        }
        if(moveInput < 0)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
            faceRight = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "target")
        {
            return;
        }


        //if collision is target, ignore the collider
        Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());


        //Physics2D.IgnoreCollision(collision.collider, myFeet);
        //Physics2D.IgnoreCollision(collision.collider, myHead);
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        
    }






}
