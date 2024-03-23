using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface NameGender
{
    public void SetName(TMP_InputField nameInput)
    {
        PlayerPrefs.SetString("name", nameInput.text.ToString());
    }

    public void GetName(TMP_Text nameText)
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
            return PlayerPrefs.GetInt("gender");
        }
        else
        {
            return 1;
        }
    }
}
