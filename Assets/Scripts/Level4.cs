using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Level4 : MonoBehaviour
{
    public List<string> equations;
    public List<int> answers;

    public TMP_Text equationsText, namePiece;
    public TMP_InputField ansInputField;

   

    int currentEquation;

    public GameObject errorWindow, correctWindow, gameFailedWindow;
    public TMP_Text text;

    int errorCout=0;

    Animator animator;
    public GameObject male, female;

    private void Start()
    {
        GetRandomEquation();
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
        GetName(namePiece);
    }

    public void GetRandomEquation()
    {
        ansInputField.text = null;
        currentEquation = Random.Range(0, equations.Count);
        equationsText.text = equations[currentEquation];
    }
    public void GetName(TMP_Text nameText)
    {
        if (PlayerPrefs.HasKey("name"))
        {
            nameText.text = PlayerPrefs.GetString("name");
        }
    }

    public void SubmitAns()
    {
        int ans = int.Parse( ansInputField.text);

        if(ans == answers[currentEquation])
        {
            text.text = "printf(\"My name is " + PlayerPrefs.GetString("name") + "\");" ;
            correctWindow.SetActive(true);
        }
        else
        {
            
            errorCout++;
            if(errorCout == 3)
            {
                gameFailedWindow.SetActive(true);
            }
            else
            {
                errorWindow.SetActive(true);
            }
        }
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

    public void PlayPickUp()
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
