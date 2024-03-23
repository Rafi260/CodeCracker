using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject gameoverWindow, sucker;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameoverWindow.SetActive(true);
            sucker.SetActive(false);
            
                collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
           
        }
    }
}
