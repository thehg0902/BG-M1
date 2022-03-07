using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBody : MonoBehaviour
{
   

    public GameObject mainCharacter;
    public GameObject currentTarget;


    public Transform cameraZ;


    public float transrDist;
    public float maxDist;
    private float targetDist;
    Vector2 mousePos2D;
    private float mouseDist;

    private float fov = 8.5f;
    public float farSightDist;

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

        //mouse clicked on object with tag of "target"
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

        //canera orthSize = fov
        gameManager.Vcamera.m_Lens.OrthographicSize = fov;
        //far sight zoom in and out
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if(fov < farSightDist)
            {
                fov+=0.05f;
            }
        }
        else
        {
            if(fov> 8.5f)
            {
                fov -= 0.05f;
            }
            
        }



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
        //if you are the main character, disable move on MC and activate move on Tartet
        if (currentTarget == mainCharacter)
        {
            mainCharacter.GetComponent<playerMov>().enabled = false;
            mainCharacter.GetComponent<playerAnim>().enabled = false;
            currentTarget = player;
            player.GetComponent<E1Mov>().enabled = true;
            player.GetComponent<E1Anim>().enabled = true;
            gameManager.Vcamera.m_Follow = player.transform;
        }
        //
        else {
            currentTarget.gameObject.GetComponent<E1Mov>().enabled = false;
            currentTarget.gameObject.GetComponent<E1Anim>().enabled = false;
            currentTarget = player;
            player.GetComponent<E1Mov>().enabled = true;
            player.GetComponent<E1Anim>().enabled = true;
            gameManager.Vcamera.m_Follow = player.transform;
        }
            
    }



    void backToMain()
    {
        if(currentTarget != mainCharacter)
        {
            mainCharacter.transform.eulerAngles = new Vector3(0, 0, 0);
            currentTarget.gameObject.GetComponent<E1Mov>().enabled = false;
            currentTarget.gameObject.GetComponent<E1Anim>().enabled = false;
            currentTarget = mainCharacter;
            mainCharacter.GetComponent<playerMov>().enabled = true;
            mainCharacter.GetComponent<playerAnim>().enabled = true;
            gameManager.Vcamera.m_Follow = mainCharacter.transform;
            //camera.ForceCameraPosition(mainCharacter.transform.position, Quaternion.Euler(0, 0, 0));

        }
        else { return; }


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
