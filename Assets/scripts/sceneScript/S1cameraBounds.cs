using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1cameraBounds : MonoBehaviour
{
    float camXoffset = 10;
    float camYoffset;
    public Cinemachine.CinemachineVirtualCamera camera;

 
   
    [SerializeField]  float leftLim;
    [SerializeField]  float rightLim;
    [SerializeField]  float topLim;
    [SerializeField]  float botLim;

    private void Update()
    {
        
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector2(leftLim, topLim), new Vector2(leftLim, botLim));
        Gizmos.DrawLine(new Vector2(leftLim, botLim), new Vector2(rightLim, botLim));

        Gizmos.DrawLine(new Vector2(leftLim, topLim), new Vector2(rightLim, topLim));
        Gizmos.DrawLine(new Vector2(rightLim, botLim), new Vector2(rightLim, topLim));
    }
}
