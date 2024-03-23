using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceHolder : MonoBehaviour
{
    public int ID;
    

    public void Attach(Transform pieceTransform)
    {
        pieceTransform.parent = this.transform;
        pieceTransform.localPosition = Vector3.zero;
        pieceTransform.localRotation = Quaternion.identity;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            Piece pHolder = collider.gameObject.GetComponent<Piece>();
            print("Hiiii");
            if (pHolder != null && pHolder.ID == ID)
            {
                pHolder.Attach(this);
            }
        }
    }

}
