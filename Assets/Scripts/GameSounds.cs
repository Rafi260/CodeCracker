using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{
    public AudioClip success, success2, explosion, crystalBreak, buttonTap, gunShot;
    AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    public void PlaySuccess()
    {
        audioSource.PlayOneShot(success);
    }
    public void PlaySuccess2()
    {
        audioSource.PlayOneShot(success2);
    }
    public void PlayExplosion()
    {
        audioSource.PlayOneShot(explosion);
    }
    public void PlayHammer()
    {
        audioSource.PlayOneShot(crystalBreak);
    }
    public void PlayButton()
    {
        audioSource.PlayOneShot(buttonTap);
    }
    public void PlayShot()
    {
        audioSource.PlayOneShot(gunShot);
    }

}
