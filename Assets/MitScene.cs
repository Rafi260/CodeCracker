
using UnityEngine;

public class MitScene : MonoBehaviour
{
    public GameObject male, female;

    Animator animator;

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

        if(animator != null)
        animator.Play("fly");
    }
    public int GetGender()
    {
        if (PlayerPrefs.HasKey("gender"))
        {
            print(PlayerPrefs.GetInt("gender"));
            return PlayerPrefs.GetInt("gender");
        }
        else
        {
            return 1;
        }
    }
}
