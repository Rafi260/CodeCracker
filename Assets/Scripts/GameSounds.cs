using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{
    public AudioClip success, explosion, crystalBreak, buttonTap, gunShot;
    AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    public void PlaySuccess()
    {
        audioSource.PlayOneShot(success);
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
