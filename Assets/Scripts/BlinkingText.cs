using System;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{

    public Color color1;
    public Color color2;
    public TMP_Text myText;

    void Update()
    {
        Blink();
    }

    void Blink()
    {
        myText.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 1));
    }
}
