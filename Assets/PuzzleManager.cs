using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Video;

public class PuzzleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int placedPuzzlePieceCount;
    public Transform leftGate, rightGate;
    public GameObject gameEndScene;
    public GameObject spark;

    public GameObject videoObj;
    public VideoPlayer player;
    public GameObject lastImag;
    IEnumerator Start()
    {
        yield return new WaitUntil(()=> placedPuzzlePieceCount >= 6);
        spark.SetActive(true);
        videoObj.SetActive(true);
        player.Play();
        Invoke("ShowLast", 3);


     /*   leftGate.DOMoveX(-1.36f, 3f);
        rightGate.DOMoveX(-1.36f, 3f).OnComplete(() => { 
        
            gameEndScene.SetActive(true);
        
        });*/
    }

    void ShowLast()
    {
        lastImag.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
