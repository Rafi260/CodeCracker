using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucker : MonoBehaviour
{
    public GameObject beloon;
    public float suckingRange = 5f, speed = 1;
    bool beloonMove = true;
    Rigidbody2D rb;

    bool moveWithCarsor = false;

    private void Start()
    {
       rb = beloon.GetComponent<Rigidbody2D>();
    }


    private void OnMouseDown()
    {
        moveWithCarsor = true;
    }

    private void OnMouseUp()
    {
        moveWithCarsor = false;
    }

    private void Update()
    {
        if(moveWithCarsor)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos = new Vector2(pos.x, pos.y);
            transform.position =pos;
        }
        
        if(Vector3.Distance( transform.position, beloon.transform.position) <= suckingRange)
        {
            beloonMove = true;
        }
        else
        {
            beloonMove = false;
        }

        if(beloonMove)
        {
            beloon.transform.position = Vector3.MoveTowards(beloon.transform.position,transform.position, speed* Time.deltaTime);                
        }
        else
        {
            beloon.transform.position = Vector3.MoveTowards(beloon.transform.position,new Vector2( beloon.transform.position.x, beloon.transform.position.y+10), speed * Time.deltaTime);
        }
    }
}
