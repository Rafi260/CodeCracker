using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Level1 : MonoBehaviour, NameGender
{
    int prevPressedIndex = 0;
    public GameObject loseScreen, winScreen, introScreen;
    public Sprite poopedImage;
    public List<GameObject> beloons, codeUi;
    public int winningIndex = 5;

    public GameObject male, female, beloonWala;

    public RectTransform Target;

   

    public Animation playerWinAnimation;
  
    public GameObject player,env1,env2,pos,pos2;
    Animator animator;

    private void Start()
    {
        StartCoroutine(PlayGameScreen());
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

    IEnumerator PlayGameScreen()
    {
        yield return new WaitForSeconds(3);
        introScreen.SetActive(true);
    }

    public void Pressed(int index)
    {
        beloons[index-1].GetComponent<UISpriteAnimation>().Func_PlayUIAnim();
        if(prevPressedIndex + 1 == index)
        {
            prevPressedIndex = index;

            if(codeUi[index - 1])
                codeUi[index-1].SetActive(true);
            
            if(prevPressedIndex == 5)
            {
                Win();
            }
        }
        else
        {
            Lose();
        }
    }

    void Lose()
    {
        loseScreen.SetActive(true);
    }

    void Win()
    {
        winScreen.SetActive(true);
    }

    public void PlayPlayerAnimation()
    {
        playerWinAnimation.Play();
    }

    public void MiddleScreen()
    {
        env1.SetActive(false);
        beloonWala.SetActive(false);
        env2.SetActive(true);
        
        player.transform.localPosition = pos.transform.position;
        player.transform.DOMove(pos2.transform.position, 5).OnComplete(() =>
        {
            NestLevel();
        });

        female.transform.localPosition = pos.transform.position;
        female.transform.DOMove(pos2.transform.position, 5).OnComplete(() =>
        {
            NestLevel();
        });

    }
    void NestLevel()
    {
        SceneManager.LoadScene("Level2");
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
        if (animator != null)
            animator.Play("idle");

        beloonWala.GetComponent<Animator>().Play("play");

    }

    public void PlayWalk()
    {
        if (animator != null)
            animator.Play("walk");

        beloonWala.GetComponent<Animator>().Play("walk");

    }

    public void LeftRight()
    {
        print("r");
        if(male)
            male.transform.Rotate(0, 180, 0);
        if(female)
            female.transform.Rotate(0, 180, 0);
        
    }
    public void PlayDance()
    {
        animator.Play("dance");
    }

    public void Shoot()
    {
        float minDistance = 10000000;
        int index = -1;


        for (int i=0;i<beloons.Count;i++)
        {
            RectTransform rt = beloons[i].GetComponent<RectTransform>();
            float a = Vector2.Distance(rt.position, Target.position);

            if(a < minDistance)
            {
                minDistance = a;
                index = i;
            }
        }
        if(minDistance <= 50)
        {
            Pressed(index+1);
        }


    }



}
