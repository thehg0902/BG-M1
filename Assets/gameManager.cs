using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static Cinemachine.CinemachineVirtualCamera Vcamera;
    public GameObject camHolder;

    void Start()
    {
        Vcamera = camHolder.GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }




}
