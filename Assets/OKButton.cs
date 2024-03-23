using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OKButton : MonoBehaviour
{
    // Create a UnityEvent for OnMouseDown
    public UnityEvent onMouseDownEvent;

    private void OnMouseDown()
    {
        // Invoke the UnityEvent when the object is clicked
        onMouseDownEvent.Invoke();
    }
}
