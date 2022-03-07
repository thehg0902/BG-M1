using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1 : MonoBehaviour
{
    public Animator anim;
    private bool open = false;
    public GameObject frontGate;
    public Cinemachine.CinemachineVirtualCamera camera;

    //public Cinemachine.CinemachineBasicMultiChannelPerlin camShake;
    public float intensity;

    public GameObject player;

    private bool opened = false;
    

    
    private Renderer sprite;

    [SerializeField] private Color colorTurn = Color.white;
    [SerializeField] private Color colorTurnBack = Color.white;

    public PlatformEffector2D gate;

    private void Start()
    {
        sprite = GetComponent<Renderer>();
    }


    private void Update()
    {
        if (open)
        {
            anim.SetBool("open", true);
        }
        if(!open) 
        { 
            anim.SetBool("open", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            //turn color
            sprite.material.color = colorTurn;

            if (!opened) {
                
                StartCoroutine(openGate());
                
            }
            else
            {
                open = true;
                gate.enabled = true;
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            sprite.material.color = colorTurnBack;
            //Debug.Log("close");
            open = false;
            gate.enabled = false;
        }
 
    }
  


    IEnumerator openGate()
    {
        
        gate.enabled = true;
        yield return new WaitForSeconds(1);
        camera.m_Follow = frontGate.transform;
        yield return new WaitForSeconds(1);
        open = true;
        
        //camShake.m_AmplitudeGain = intensity;
        yield return new WaitForSeconds(2);
        camera.m_Follow = camera.GetComponentInChildren<changeBody>().currentTarget.transform;
        

    }





}
