using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitDoor : MonoBehaviour
{
    public GameObject but1;
    public GameObject but2;

    private Animator anim;


    public static float sceneIndex;


    private void Start()
    {
        sceneIndex = 1f;
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (but1.GetComponent<generalButton>().Active1 == true && but2.GetComponent<generalButton>().Active1 == true) {
            Debug.Log("open door");
            anim.SetBool("open", true);

        }
        else
        {
            anim.SetBool("open", false);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneIndex = 2;
    }




}
