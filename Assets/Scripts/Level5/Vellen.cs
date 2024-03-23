
using System.Collections;
using UnityEngine;

public class Vellen : MonoBehaviour
{
    public GameObject bullet;
    float time;
    bool stopFiring = false;
    public Animator animator;

    public void _Start()
    {
        StartCoroutine(startFiring());
    }

    public IEnumerator startFiring()
    {
        while(!stopFiring)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(bullet, transform.position, Quaternion.identity);
            animator.Play("fire");
        }
    } 
    
    public void StopFiring()
    {
        stopFiring = true;
    }

    public void PlayWalk()
    {
        animator.Play("FireWalk");
    }
}
