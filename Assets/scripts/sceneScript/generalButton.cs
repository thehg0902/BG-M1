using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalButton : MonoBehaviour
{
    public GameObject targetObj;
    public bool Active1 = false;

    [SerializeField] private Color colorActive = Color.white;
    [SerializeField] private Color colorDeactive = Color.white;

    private Renderer sprite;


    private void Start()
    {
        sprite = GetComponent<Renderer>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "target")
        {
            Active1 = true;
            sprite.material.color = colorActive;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "target")
        {
            Active1 = false;
            sprite.material.color = colorDeactive;
        }
    }




}
