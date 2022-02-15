using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBody : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera camera;
    public GameObject mainCharacter;

    public GameObject currentTarget;


    public Transform cameraZ;


    public float transrDist;
    public float maxDist;
    private float targetDist;
    Vector2 mousePos2D;
    private float mouseDist;




    private void Awake()
    {
        //camera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    void Start()
    {
        currentTarget = mainCharacter;
    }


    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         mousePos2D =  new Vector2(mousePos.x, mousePos.y);

        targetDist = Vector2.Distance(mainCharacter.transform.position, currentTarget.transform.position);

        //mouseDist = Vector2.Distance(mainCharacter.transform.position, mousePos2D);


        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(gameObject.name) ;
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null && hit.transform.gameObject.tag != "Untagged")
            {
                if (hit.collider.gameObject.tag == "target")
                {
                    changeCharacter(hit.collider.gameObject);
                    //W421.H235

                }

            }  


        }// end mouseclick


        if(targetDist >= maxDist)
        {
            backToMain();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            backToMain();
        }

    }//end update


    void changeCharacter(GameObject player)
    {
        if (currentTarget == mainCharacter)
        {
            mainCharacter.GetComponent<playerMov>().enabled = false;
            mainCharacter.GetComponent<playerAnim>().enabled = false;
            currentTarget = player;
            player.GetComponent<E1Mov>().enabled = true;
            player.GetComponent<E1Anim>().enabled = true;
            camera.m_Follow = player.transform;
        }
        else {
            currentTarget.gameObject.GetComponent<E1Mov>().enabled = false;
            currentTarget.gameObject.GetComponent<E1Anim>().enabled = false;
            currentTarget = player;
            player.GetComponent<E1Mov>().enabled = true;
            player.GetComponent<E1Anim>().enabled = true;
            camera.m_Follow = player.transform;
        }
            
    }



    void backToMain()
    {
        mainCharacter.transform.eulerAngles = new Vector3(0, 0, 0);
        currentTarget.gameObject.GetComponent<E1Mov>().enabled = false;
        currentTarget.gameObject.GetComponent<E1Anim>().enabled = false;
        currentTarget = mainCharacter;
        mainCharacter.GetComponent<playerMov>().enabled = true;
        mainCharacter.GetComponent<playerAnim>().enabled = true;
        camera.m_Follow = mainCharacter.transform;
        //camera.ForceCameraPosition(mainCharacter.transform.position, Quaternion.Euler(0, 0, 0));
        
        
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(mainCharacter.transform.position, mousePos2D);
        Gizmos.DrawWireSphere(mainCharacter.transform.position, transrDist);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mainCharacter.transform.position, maxDist);
    }


}
