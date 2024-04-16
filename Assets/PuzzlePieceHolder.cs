using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceHolder : MonoBehaviour
{
    public int ID;
    
    public PuzzleManager manager;
    public GameSounds sound;

    private void Awake()
    {
        manager = FindAnyObjectByType<PuzzleManager>();
    }
    public void Attach(Transform pieceTransform)
    {
        manager.placedPuzzlePieceCount++;
        pieceTransform.parent = this.transform;
        pieceTransform.localPosition = Vector3.zero;
        pieceTransform.localRotation = Quaternion.identity;
        //print("g");
        sound.PlaySuccess2();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            Piece puzzlePiece = collider.gameObject.GetComponent<Piece>();
            //print("Hiiii");
            if (puzzlePiece != null && puzzlePiece.ID == ID)
            {
                puzzlePiece.Attach(this);
                Attach(puzzlePiece.transform);
            }
        }
    }

}
