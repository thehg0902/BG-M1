using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    private float moveInput;
    private bool isMoving = false;

    public Animator anim;
    //public Component playerMov;
    // Start is called before the first frame update
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (moveInput != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }




        if (isMoving == true)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

    }
}
