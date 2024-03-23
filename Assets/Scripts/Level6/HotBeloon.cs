using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HotBeloon : MonoBehaviour
{
    public float speed = 5;
    public GameObject winScreen, loseScreen;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = Vector2.MoveTowards(transform.position, new Vector2( transform.position.x, mousePos.y), speed*Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(loseScreen) loseScreen.SetActive(true);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        rb.gravityScale = 3.0f;
    }
}
