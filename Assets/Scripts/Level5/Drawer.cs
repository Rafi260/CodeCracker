using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drawer : MonoBehaviour
{
    public GameObject male,female, playerPosition , codeSection, player;
    public string code;
    public GameObject drawerSprite;
    public Manager manager;

    public GameObject UiCode;
    public bool left = true;
    
    

    public GameObject vellan, leftPos, rightPos;

    bool clicked = false;
    DrawerManager drawerManager;

    private void Start()
    {
        drawerManager = GetComponentInParent<DrawerManager>();
    }
    private void OnMouseDown()
    {
        if(!clicked && drawerManager.gameStarted)
        {
            StopAllCoroutines();
            Left();


            
            clicked = true;
            if(player.transform.position != playerPosition.transform.position)
                manager.PlayWalk();

            player.transform.DOMove(playerPosition.transform.position, 3).OnComplete(() =>
            {
                manager.PlayIdle();

            });
            /*female.transform.DOMove(playerPosition.transform.position, 3).OnComplete(() =>
            {
                //manager.PlayIdle();

            });*/
            
            drawerSprite.SetActive(false);
            if (code != null && UiCode != null)
            {
                codeSection.gameObject.SetActive(true);
                UiCode.SetActive(true);
            }
        }
      

    }



    public void Left()
    {
        if (left)
        {
            //female.transform.eulerAngles = new Vector3(0, 0, 0);
            player.transform.eulerAngles = new Vector3(0, 0, 0);

            vellan.transform.DOMove(rightPos.transform.position, 2);
            vellan.transform.eulerAngles = new Vector3(0, 180, 0);

            vellan.GetComponent<Animator>().Play("FireWalk");

        }
        else
        {
            //female.transform.eulerAngles = new Vector3(0, 180, 0);
            player.transform.eulerAngles = new Vector3(0, 180, 0);

            vellan.transform.DOMove(leftPos.transform.position, 2);
            vellan.transform.eulerAngles = new Vector3(0, 0, 0);
        }   
    }
}
