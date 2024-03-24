using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Bomb : MonoBehaviour
{
    Vector3 endPos;
    public float time,a;
    float currentTime;
    Image imageSlider;
    void Start()
    {
       
        Jump();
    }

    void Awake()
    {
        imageSlider = GameObject.FindGameObjectWithTag("slider").GetComponent<Image>();
        imageSlider.enabled = true;
        endPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        endPos.y -= a;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            imageSlider.fillAmount = 0;
            Destroy(gameObject, .2f);

        }
        else
        {
            if(imageSlider)
            imageSlider.fillAmount = time / 5;
        }

        Vector3 targetPositionScreenSpace = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        imageSlider.rectTransform.position = targetPositionScreenSpace;
    }

   

    void Jump()
    {
        transform.DOJump(endPos,1,1,1);
    }
}
