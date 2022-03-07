using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class p_farSight : MonoBehaviour
{
 
    public GameObject looktarget;


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("look!");
            //gameManager.Vcamera.m_LookAt = looktarget.transform;
            //gameManager.Vtransponder.m_FollowOffset.x = 1;
            gameManager.Vfreelook.m_LookAt = looktarget.transform;
            //gameManager.Vcamera
            
        }

       
    }








    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(mainCharacter.transform.position, mousePos2D);
    }


}
