using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Mov : MonoBehaviour
{
    //move var
    public float speed;
    public float jumpforce;
    private Rigidbody2D rb2d;
    private float moveInput;

    //face direction var
    private bool faceRight;


    //groundcheck var\
    private bool grounded;
    public Transform checkPos;
    public float checkRad;
    public LayerMask whatIsGround;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(checkPos.position, checkRad, whatIsGround);



        moveInput = Input.GetAxis("Horizontal");


        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        if (!faceRight && moveInput < 0)
        {
            flip();
        }else if(faceRight && moveInput > 0)
        {
            flip();
        }
    }


     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded ==true)
        {
            Debug.Log("jump");
            rb2d.velocity = Vector2.up * jumpforce;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(checkPos.position, checkRad);
    }



    void flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
