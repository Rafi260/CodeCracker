
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;

public class LevelLoader : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());
    }

    public void LevelLobby()
    {
        StartCoroutine(PAniumation("Lobby"));
    }
    public void Level1()
    {
        StartCoroutine(PAniumation("Level1"));
    }
    public void Level2()
    {
        StartCoroutine(PAniumation("Level2"));
    }

    public void Level3()
    {
        StartCoroutine(PAniumation("Level3"));
    }
    public void Level4()
    {
        StartCoroutine(PAniumation("Level4"));
    }
    public void Level5()
    {
        StartCoroutine(PAniumation("Level5"));
    }
    public void Level6()
    {
        StartCoroutine(PAniumation("Level6"));
        
    }
    public void LastLevel()
    {
        StartCoroutine(PAniumation("MIT Scene final"));

    }
    public void Exit()
    {
        Application.Quit();
    }


    IEnumerator PAniumation(string Level)
    {
        print("Playing animation");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Level);
    }

}
