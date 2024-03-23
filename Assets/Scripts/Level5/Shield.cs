using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{

    public float health=100, damage=7;


    public Slider healthSlider;

    private void Update()
    {
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health -= damage;
            healthSlider.value = health / 100;
        }
    }

    public void FullHealth()
    {
        health = 100;
        healthSlider.value = 1;
    }
}
