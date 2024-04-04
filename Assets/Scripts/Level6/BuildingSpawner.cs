using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public List<GameObject> buildings = new List<GameObject>();

    public float spawnInterval = 1, gameTime = 20f;
    float currentTime = 0;
    public TMP_Text timetext;
    bool startSpawning = false;
    public GameObject winWindow, loseWindow;
    public GameObject male, female, baloon;
    public LinishLine finishLine;
    public GameSounds sounds;

    bool stopSpawning = false;
    private void Start()
    {
        if (male != null && female != null)
        {
            if (GetGender() == 0)
            {
                male.SetActive(true);
            }

            else
            {
                female.SetActive(true);

            }

        }
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

    bool finishLineSpawned = false;

    private void Update()
    {
        if (startSpawning)
        {
            if (Time.time - currentTime > spawnInterval)
            {
                currentTime = Time.time;
                int a = Random.Range(0, buildings.Count);
                Instantiate(buildings[a], transform.position, Quaternion.identity);
            }
            if(gameTime>=0)
                gameTime -= Time.deltaTime;

            //print(gameTime);

            timetext.text = gameTime.ToString("F2");

            if (gameTime <= 0 && !loseWindow.activeSelf)
            {
                StopSpawn();
                //

                //winWindow.SetActive(true);
                if(!finishLineSpawned)
                {
                    finishLineSpawned = true;
                    baloon.GetComponent<BoxCollider2D>().enabled = false;
                    finishLine.go = true;
                }
                
            }
        }
        else
        {
            timetext.text = "00";
        }
       
    }

    public void Spawn()
    {
        startSpawning = true;
        int a = Random.Range(0, buildings.Count);
        Instantiate(buildings[a], transform.position, Quaternion.identity);
    }
    public void StopSpawn()
    {
        startSpawning = false;
    }
}
