using TMPro;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int ID;
    private bool attached = false;
    private Vector3 startPosition;
    public TMP_Text name;
    void Start()
    {
        startPosition = transform.position;
        if (name != null) name.text = $"My name is {PlayerPrefs.GetString("userName", "user1")}";
    }

    void OnMouseDown()
    {
        if (!attached)
        {
            Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.SetAsLastSibling();
        }
    }

    void OnMouseDrag()
    {
        if (!attached)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        if (!attached)
        {
            transform.position = startPosition;
        }
    }

   
    public void Attach(PuzzlePieceHolder pHolder)
    {
        attached = true;
    }
}
