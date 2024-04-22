using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerManager : MonoBehaviour
{
   public bool gameStarted = false;

    private void Start()
    {
        gameStarted = false;
    }

    public void GameStartFun()
    {
        gameStarted = true;
    }
}
