using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class belon : MonoBehaviour
{
    public GameObject winWindow;
    Animator animator;
    public GameObject male, female;
    public GameSounds sounds;

    private void Start()
    {
       
        if (GetGender() == 0)
        {
            male.SetActive(true);
            animator = male.GetComponent<Animator>();
        }
        else
        {
            female.SetActive(true);
            animator = female.GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("table")) { 
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            sounds.PlaySuccess();
            winWindow.SetActive(true); }
    }



    public int GetGender()
    {
        if (PlayerPrefs.HasKey("gender"))
        {
            return PlayerPrefs.GetInt("gender");
        }
        else
        {
            return 1;
        }
    }

    public void PlayIdle()
    {
        if (animator != null)
            animator.Play("idle");

        

    }

    public void PlayWalk()
    {
        if (animator != null)
            animator.Play("walk");

      

    }

    public void LeftRight()
    {
        print("r");
        if (male)
            male.transform.Rotate(0, 180, 0);
        if (female)
            female.transform.Rotate(0, 180, 0);

    }
    public void PlayDance()
    {
        animator.Play("dance");
    }


}
