using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextAnimation : MonoBehaviour
{
    public TMP_Text text;
    public AnimationType animationType = AnimationType.RevealCharacter;

    public enum AnimationType
    {
        RevealCharacter
        // Add more animation types as needed
    }

    void OnEnable()
    {

        if (!text)
        {
            text = GetComponent<TMP_Text>();
        }
        PlayTextAnimation();
    }

    void PlayTextAnimation()
    {
        switch (animationType)
        {
            case AnimationType.RevealCharacter:
                StartCoroutine(RevealCharacterAnimation());
                break;

            default:
                Debug.LogWarning("Unsupported AnimationType");
                break;
        }
    }
    IEnumerator RevealCharacterAnimation()
    {
        int totalCharacters = text.text.Length;

        for (int i = 0; i < totalCharacters; i++)
        {
            yield return new WaitForSeconds(0.1f); // Adjust time delay as needed
            text.maxVisibleCharacters = i + 1;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayTextAnimation();
        }
    }
}
