using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class LobbyManager : MonoBehaviour
{

    public Transform[] players;
    public CanvasGroup canvasGroupOfUsername;


    public void SetName(TMP_InputField nameInputField)
    {
        if (!string.IsNullOrEmpty(nameInputField.text.ToString()))
        {
            PlayerPrefs.SetString("userName", nameInputField.text.ToString());
            float value = 1;
            DOTween.To(() => value, x => value = x, 0, 0.6f)
                .OnUpdate(() => {
                   canvasGroupOfUsername.alpha = value;
                }).OnComplete(() => {

                    SceneManager.LoadScene(1);
                
                });
           
        }
       
    }
}
