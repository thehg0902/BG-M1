using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Anim : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private float moveInput;
    private bool isMoving;


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
