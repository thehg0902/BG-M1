using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera camera;
    private float length, startpos;
    public float paralaxEffect;


    private void Start()
    {
        startpos = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        float dist = camera.transform.position.x * paralaxEffect;
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }






}
