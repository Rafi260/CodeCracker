using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
public class Level2 : MonoBehaviour
{
    public GameObject env,male,pos,pos2,pos3,pos4,pos5, female;
    public GameObject HammerButton, hitButton, codePieces;

    public GameObject _int,_main,_braces;
    public GameObject intLoc,mainLoc,bracLoc;
    public GameObject winScreen;
    public GameObject collectionPoint,lastPoint, instractionWindow;

    Animator animator;
    public
    

    int hitCount=0;

    private void Start()
    {
        if (GetGender() == 0)
        {
            male.SetActive(true);
            animator = male.GetComponent<Animator>();
        }
        else
        {
            female.SetActive(true);
            animator = female.GetComponent<Animator>();
        }

        if (animator != null)
            animator.Play("walk");
    }
    public void Switch()
    {
        env.SetActive(false);
        codePieces.SetActive(true);
        male.transform.localPosition = pos.transform.position;
        male.transform.DOMove(pos2.transform.position, .3f).OnComplete(() =>
        {
            
            male.transform.DOMove(pos3.transform.position, .3f).OnComplete(() =>
            {
                instractionWindow.SetActive(true);
               
            });
        });

        female.transform.localPosition = pos.transform.position;
        female.transform.DOMove(pos2.transform.position, .3f).OnComplete(() =>
        {

            female.transform.DOMove(pos3.transform.position, .3f).OnComplete(() =>
            {
                instractionWindow.SetActive(true);
                PlayIdle();
            });
        });
    }

    public void PlayGame()
    {
        LeftRight();
        PlayWalk();
        male.transform.DOMove(pos4.transform.position, 1f).OnComplete(() =>
        {
            Showhammer();
            PlayIdle();
        });

        female.transform.DOMove(pos4.transform.position, 1f).OnComplete(() =>
        {
            Showhammer();
            PlayIdle();

        });
    }

    void Showhammer()
    {
        HammerButton.SetActive(true);
    }

    public void TakeHammer()
    {
        animator.Play("hammerPick");
        Invoke("GoToOrb", 2.5f);
    }

    public void GoToOrb()
    {
        LeftRight();
        PlayWalk();
        male.transform.DOMove(pos5.transform.position, 1f).OnComplete(() =>
        {
            hitButton.SetActive(true);
            PlayIdle();

        });
        female.transform.DOMove(pos5.transform.position, 1f).OnComplete(() =>
        {
            hitButton.SetActive(true);
            PlayIdle();

        });
    }


    public void Hit()
    {
        hitCount++;
        if (hitCount==3)
        {
            _int.SetActive(true);
            _int.transform.DOMove(intLoc.transform.position, 1f);
        }
        else if(hitCount==6)
        {
            _main.SetActive(true);
            _main.transform.DOMove(mainLoc.transform.position, 1f);
        }
        else if (hitCount == 9)
        {
            _braces.SetActive(true);
            _braces.transform.DOMove(bracLoc.transform.position, 1f);

            hitButton.SetActive(false);
            StartCoroutine(Collect());
        }

        animator.Play("hit");

        
    }

    IEnumerator Collect()
    {
        yield return new WaitForSeconds(2);
        winScreen.SetActive(true );
    }

    public void CollectThem()
    {
        _int.transform.DOMove(collectionPoint.transform.position, .3f).OnComplete(() =>
        {
            _main.transform.DOMove(collectionPoint.transform.position, .3f).OnComplete(() =>
            {
                _braces.transform.DOMove(collectionPoint.transform.position, .3f).OnComplete(() =>
                {
                    male.transform.DOMove(lastPoint.transform.position, 3f).SetDelay(2);
                });
            });
        });
    }


    public int GetGender()
    {
        if (PlayerPrefs.HasKey("gender"))
        {
            return PlayerPrefs.GetInt("gender");
        }
        else
        {
            return 1;
        }
    }

    public void PlayIdle()
    {
        animator.SetBool("walk", false);
        if (animator != null)
            animator.Play("idle");


    }

    public void PlayWalk()
    {
        animator.SetBool("walk", true);
        if (animator != null)
            animator.Play("walk");


    }

    public void PlayJump()
    {
        if (animator != null)
            animator.Play("jump");


    }
    public void PlayDance()
    {
        print("Dance");
        animator.Play("dance");
    }

    public void LeftRight()
    {
        print("r");
        if (male)
            male.transform.Rotate(0, 180, 0);
        if (female)
            female.transform.Rotate(0, 180, 0);

    }
}
