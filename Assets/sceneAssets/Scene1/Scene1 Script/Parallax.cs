using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // public Cinemachine.CinemachineVirtualCamera camera;
    private float length, startpos;
    public  float paralaxEffect;
    private bool paralaxEnabled = false;
    public Transform mainCam;


    private bool globalParalaxManager;
    private GameObject globalMainCam;

    private void Start()
    {
        globalMainCam = paralaxManager.mainCamera;
        //camera position
        startpos = mainCam.transform.position.x;
        //camera size
       // length = camera.m_Lens.OrthographicSize;
        //global manager
        globalParalaxManager = paralaxManager.globalParalax;
    }
    private void FixedUpdate()
    {
        //Debug.Log(globalParalaxManager);

        if (!globalParalaxManager)
        {
            return;
        }
        paralaxEnabled = true;




        if (paralaxEnabled)
        {
            float dist = mainCam.transform.position.x * paralaxEffect;
            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        }
        else
        {
            return;
        }
    


    }






}
