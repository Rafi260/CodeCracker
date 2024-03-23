using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Transform mit;
    public bool gameStarted;
    public TMP_Text welcomeText;
    void Start()
    {
        welcomeText.text = $"Welcome {PlayerPrefs.GetString("userName")}";
        welcomeText.gameObject.SetActive(false);
        mit.localPosition = -12 * Vector3.up;
        mit.DOLocalMove(Vector3.zero, 0.6f).OnComplete(() => {

            welcomeText.gameObject.SetActive(true);
            welcomeText.GetComponent<TextAnimation>().enabled = true;
            gameStarted = true;
        });
    }

    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber + 1);
    }
}
