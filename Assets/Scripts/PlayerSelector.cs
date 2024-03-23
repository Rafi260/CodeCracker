using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
   
    int gender; // 0 = male, 1 = female

    public GameObject male,male1, female, female1;

    private void Start()
    {
        if(male != null && female != null)
        {
            if (GetGender() == 0)
            {
                male.SetActive(true);
                male1.SetActive(true);
            }

            else
            {
                female.SetActive(true);
                female1.SetActive(true);

                female.GetComponent<Animator>().Play("fly");
            }

        }
    }

    public void SetName(TMP_InputField nameInput)
    {
        PlayerPrefs.SetString("name", nameInput.text.ToString());
    }

    public void  GetName(TMP_Text nameText)   
    {
        if (PlayerPrefs.HasKey("name"))
        {
            nameText.text = PlayerPrefs.GetString("name");
        }
    }

    public void SetGender(int a)
    {
        PlayerPrefs.SetInt("gender", a);
    }

    public int GetGender()
    {
        if (PlayerPrefs.HasKey("gender"))
        {
             return  PlayerPrefs.GetInt("gender");
        }
        else
        {
            return 1;
        }
    }
}
