using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinishLine : MonoBehaviour
{
    public GameObject winWindow;
    public bool go = false;
    public float speed;
    private void FixedUpdate()
    {
        if(go) 
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            winWindow.SetActive(true);
        }
    }
}
