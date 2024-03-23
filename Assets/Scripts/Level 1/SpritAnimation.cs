using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class SpritAnimation : MonoBehaviour
{

    public SpriteRenderer m_Image;

    public Sprite[] m_SpriteArray;
    public float m_Speed = .02f;

    private int m_IndexSprite;
    Coroutine m_CorotineAnim;
    bool IsDone;

    int hitCount = -1;

    private void Start()
    {

        //Func_PlayUIAnim();
    }

    public void Hit()
    {
        hitCount++;
        print(hitCount);
        if( (hitCount + 1) %3 == 0 && (hitCount + 1) < 10)
        {
            print("Inside");
            m_IndexSprite++;
            m_Image.sprite = m_SpriteArray[m_IndexSprite];

            if (m_IndexSprite >= 8)
            {
                
            }
        }
        if((hitCount + 1) >=9)        {
            Func_PlayUIAnim();
        }
       


    }

    public void Func_PlayUIAnim()
    {

        IsDone = false;
        StartCoroutine(Func_PlayAnimUI());
    }

    public void Func_StopUIAnim()
    {
        IsDone = true;
        StopCoroutine(Func_PlayAnimUI());
    }
    IEnumerator Func_PlayAnimUI()
    {

        yield return new WaitForSeconds(m_Speed);
        if (m_IndexSprite >= m_SpriteArray.Length)
        {
            //m_IndexSprite = 0;
            Func_StopUIAnim();
        }
        else
        {
            m_Image.sprite = m_SpriteArray[m_IndexSprite];
            m_IndexSprite += 1;
            if (IsDone == false)
                m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
        }


    }
}
