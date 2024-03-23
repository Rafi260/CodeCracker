using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Target : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private bool isDragging = false;
    private Vector2 offset;

    private void Start()
    {
        // Assuming you have a reference to the RectTransform component
        rectTransform = GetComponent<RectTransform>();

        // Assuming the UI element is under a Canvas
        canvas = GetComponentInParent<Canvas>();

        // Assuming you have a CanvasGroup component attached to your UI element
        canvasGroup = GetComponent<CanvasGroup>();

        if (rectTransform == null || canvas == null || canvasGroup == null)
        {
            Debug.LogError("Required components not found. Attach this script to a UI element with RectTransform and CanvasGroup, and ensure it is under a Canvas.");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (eventData.pointerPress == gameObject)
        {
            isDragging = true;

            // Calculate the offset between the click position and the UI element's position
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform, eventData.position, eventData.pressEventCamera, out offset);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("a");
        //if (isDragging)
        {
           
            // Move the UI element based on the drag position
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 newPosition);

            rectTransform.localPosition = newPosition - offset;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging)
        {
            isDragging = false;
        }
    }
}
