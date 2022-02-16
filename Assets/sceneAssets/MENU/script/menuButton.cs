using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler{

    public Animator anim;
    public float index;
    private bool hover;
    private bool clicked = false;
    private bool mouseOver()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }




    void FixedUpdate()
    {
        Debug.Log(hover);
        if(hover)
        {
            anim.SetBool("selected", true);

            if (!Input.GetKey(KeyCode.Mouse0))
            {
                return;
            }

            StartCoroutine(clickSequence());

            if (index == 0)
            {
                Debug.Log("startgame");
                SceneManager.LoadScene(1);
            }
            if (index == 1)
            {
                Debug.Log("ops");
            }
            if (index == 2)
            {
                Debug.Log("quit");
            }

        }


        if (hover == false)
        {
            anim.SetBool("selected", false);
            anim.SetBool("pressed", false);
        }
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    IEnumerator clickSequence()
    {
        anim.SetBool("pressed" , true);
        yield return new WaitForSeconds(1);
        anim.SetBool("pressed", false);
        anim.SetBool("selected", false) ;

    }

}
