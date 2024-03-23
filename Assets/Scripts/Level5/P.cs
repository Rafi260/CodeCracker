using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P : MonoBehaviour
{
    public GameObject lose;

    public GameObject shield, shieldButton;
    public float shieldTimer = 10, shieldButtonTimer = 8;
    public Slider  buttonSlider;
    public RectTransform shieldHealthBar;

    bool bShieldActivated = false, bButtonActivated = true;

    public Transform healthBarloc;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            lose.SetActive(true);
        }
    }

    float currentShieldTime, currentButtonTime;
    private void Update()
    {
        if(bShieldActivated)
        {
/*          currentShieldTime -= Time.deltaTime;
            if(currentShieldTime <= 0 )
            {
                shield.SetActive(false);
                bShieldActivated = false;
            }*/
        }

        if(!bButtonActivated)
        {
            currentButtonTime -= Time.deltaTime;
            buttonSlider.value = currentButtonTime / shieldButtonTimer;
            if(currentButtonTime <= 0)
            {
                shieldButton.SetActive(true);
                bButtonActivated = true;
            }
        }

        Vector3 targetPositionScreenSpace = Camera.main.WorldToScreenPoint(healthBarloc.position);

        shieldHealthBar.position = targetPositionScreenSpace;


    }

    

    public void ActivateShield()
    {
        shieldButton.SetActive(false);
        shield.SetActive(true);

        currentShieldTime = shieldTimer;
        bShieldActivated = true;

        currentButtonTime = shieldButtonTimer;
        bButtonActivated = false;
       
    }
}
