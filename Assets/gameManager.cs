using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class gameManager : MonoBehaviour
{
    public static CinemachineVirtualCamera Vcamera;
    public static CinemachineTransposer Vtransponder;
    public static CinemachineFreeLook Vfreelook;

    public GameObject camHolder;

    void Start()
    {
        Vcamera = camHolder.GetComponent<CinemachineVirtualCamera>();
        Vtransponder = camHolder.GetComponent<CinemachineTransposer>();
        Vfreelook = camHolder.GetComponent<CinemachineFreeLook>();


    }




}
