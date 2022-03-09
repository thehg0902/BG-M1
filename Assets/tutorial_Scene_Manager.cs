using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_Scene_Manager : MonoBehaviour
{
    public Transform player;

    public Transform scene1StartPos;
    public Transform scene2StartPos;

    public PolygonCollider2D confinder1;
    public PolygonCollider2D confinder2;

    private bool scene1Active = false;
    private bool scene2Active = false;



    public Animator animfade;

    private void Update()
    {

        if (!scene1Active && exitDoor.sceneIndex == 1)
        {
            scene1Active = true;
            player.position = scene1StartPos.position;
            gameManager.Vconfinder.m_BoundingShape2D = confinder1;
        }



        if (!scene2Active && exitDoor.sceneIndex == 2)
        {
            // Debug.Log("next");
            StartCoroutine(tran1_2());
        }
    }

    IEnumerator tran1_2()
    {
        animfade.SetBool("fadeOut", true);
        yield return new WaitForSeconds(1);
        scene2Active = true;
        player.position = scene2StartPos.position;
        gameManager.Vconfinder.m_BoundingShape2D = confinder2;
        yield return new WaitForSeconds(1);
        animfade.SetBool("fadeOut", false);

    }





}
