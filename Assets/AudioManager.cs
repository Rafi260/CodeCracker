using DG.Tweening;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

  
    [Header("Setting Options: Music")]

    public string musicID;
    public bool playMusic;
    public AudioSource audioSourceMusic;

    public RectTransform toggleOnParentMusic, toggleOffParentMusic;
    public GameObject toggleNobMusic;


    [Header("Setting Options: Sound Effect")]

    public string SFXID;
    public bool playSounds;
    public AudioSource audioSourceSFX;
    public RectTransform toggleOnParentSFX, toggleOffParentSFX;
    public GameObject toggleNobSFX;


    [Header("Audio Clips")]
    public AudioClip buttonClickSound1;
    public AudioClip buttonClickSound2;
    public AudioClip confettiSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip flowerAppearanceSound;
    public AudioClip LineCompleteSound;
    public AudioClip CoinsCollectedSound;
    public AudioClip lineMovingAroundBoard;
    public AudioClip tapFlower;
    public AudioClip coinAppearanceSound;
    public AudioClip coinFlyingSound;
    private void Awake()
    {

            Instance = this;
      
      
        if (audioSourceMusic == null)
        {
            audioSourceMusic = gameObject.GetComponent<AudioSource>();
        }
        if (PlayerPrefs.GetInt(musicID, 1) == 1)
        {
            playMusic = true;
        }
        else
        {
            playMusic = false;
        }


        if (PlayerPrefs.GetInt(SFXID, 1) == 1)
        {
            playSounds = true;
        }
        else
        {
            playSounds = false;
        }



        SetToggledNobMusic();
        SetToggledNobSFX();

       
    }

    public void ToggleMusic()
    {
        playMusic = !playMusic;
        if (playMusic)
        {
            PlayerPrefs.SetInt(musicID, 1);

        }
        else
        {
            PlayerPrefs.SetInt(musicID, 0);

        }
        SetToggledNobMusic();
    }

    public void SetToggledNobMusic()
    {
        if (playMusic)
        {
            audioSourceMusic.Play();
            toggleNobMusic.GetComponent<RectTransform>().SetParent(toggleOnParentMusic);
        }
        else
        {
            audioSourceMusic.Stop();
            
            toggleNobMusic.GetComponent<RectTransform>().SetParent(toggleOffParentMusic);
        }
        toggleNobMusic.GetComponent<RectTransform>().DOLocalMove(Vector3.zero, 0.1f);
    }

    public void ToggleSFX()
    {
        playSounds = !playSounds;
        if (playSounds)
        {
            PlayerPrefs.SetInt(SFXID, 1);

        }
        else
        {
            PlayerPrefs.SetInt(SFXID, 0);

        }
        SetToggledNobSFX();
    }
    public void SetToggledNobSFX()
    {
        if (playSounds)
        {
            toggleNobSFX.GetComponent<RectTransform>().SetParent(toggleOnParentSFX);
        }
        else
        {
            toggleNobSFX.GetComponent<RectTransform>().SetParent(toggleOffParentSFX);
        }
        toggleNobSFX.GetComponent<RectTransform>().DOLocalMove(Vector3.zero, 0.1f);
    }




    public void PlayButtonClickSound1()
    {
        if (buttonClickSound1 != null && playSounds)
        {
            audioSourceMusic.PlayOneShot(buttonClickSound1);
        }
    }

    public void PlayButtonClickSound2()
    {
        if (buttonClickSound2 != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(buttonClickSound2);
        }
    }

    public void PlayWinSound()
    {
        if (winSound != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(winSound);
        }
    }

    public void PlayConfettiSound()
    {
        if (confettiSound != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(confettiSound);
        }
    }
    public void PlayTapOnFlowerSound()
    {
        if (tapFlower != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(tapFlower);
        }
    }

    public void PlayLoseSound()
    {
        if (loseSound != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(loseSound);
        }
    }
    public void PlayCoinAppearSound()
    {
        if (coinAppearanceSound != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(coinAppearanceSound);
        }
    }

    public void PlayFlowerAppearanceSound()
    {
        if (flowerAppearanceSound != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(flowerAppearanceSound);
        }
    }

    public void PlayLineCompleteSound()
    {
        if (LineCompleteSound != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(LineCompleteSound);
        }
    }
    public void CoinsCollectingSound()
    {
        if (CoinsCollectedSound != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(CoinsCollectedSound);
        }
    }

    public void PlayLineMovingAroundBoard()
    {
        if (lineMovingAroundBoard != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(lineMovingAroundBoard);
        }
    }

    public void PlayCoinsFlyingSound()
    {
        if (coinFlyingSound != null && playSounds)
        {
            audioSourceSFX.PlayOneShot(coinFlyingSound);
        }
    }

}
