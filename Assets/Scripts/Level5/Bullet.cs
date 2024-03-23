using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;

    /* void Update()
     {
         transform.position = new Vector3(transform.position.x + speed, transform.position.y , transform.position.z);
     }*/

    private void Start()
    {
        FollowPlayer();
    }

    public void  FollowPlayer()
    {
        GameObject go =  GameObject.FindGameObjectWithTag("Player");
        transform.DOMove(go.transform.position, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
           
        }
    }


}
