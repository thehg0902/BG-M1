using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_farSight : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera cam;
    public GameObject looktarget;



    void Start()
    {

        //camera = gameObject.GetComponent<Cinemachine.CinemachineVirtualCamera>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.P))
        {
            //camera.m_LookAt = looktarget.transform;
        }

       
    }


    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(mainCharacter.transform.position, mousePos2D);
    }


}
