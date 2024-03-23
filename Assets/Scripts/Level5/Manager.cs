
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    int count = 0;
    public GameObject win, lose;
    public TMP_Text timeText;

    bool  bTime = true;
    Animator animator;
    public GameObject male, female, player;

    public void inc()
    {
        print("inc");
        count++;
        if(count >= 3)
        {
            bTime = false;
            player.GetComponent<BoxCollider2D>().enabled = false;
            win.SetActive(true);
        }
    }
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

        if (animator != null)
            animator.Play("walk");
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
        animator.SetBool("walk", false);
        if (animator != null)
            animator.Play("idle");


    }

    public void PlayWalk()
    {
        animator.SetBool("walk", true);
        if (animator != null)
            animator.Play("walk");
        
     

    }

    public void LeftRight()
    {
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
