using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PartTileMagnetAbility : MonoBehaviour
{
    public bool IsAbleToMagnetize;

    private PuzzleTile puzzleTile;
    private Transform puzzleTileTransformForMagnetize;

    private void OnTriggerEnter2D(Collider2D puzzleTileCollider)
    {
        if (puzzleTileCollider.TryGetComponent(out puzzleTile))
        {
            if (puzzleTile.IsFree)
            {
                IsAbleToMagnetize = true;
                puzzleTileTransformForMagnetize = puzzleTile.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D puzzleTileCollider) 
    {
        if (puzzleTileCollider.transform == puzzleTileTransformForMagnetize) 
        {
            IsAbleToMagnetize = false;
            puzzleTile.IsFree = true;
            puzzleTile.InvokeImFreeEvent();
        }
    }

    public void MagnetizeToPuzzleTile()
    {
        gameObject.transform.position = puzzleTileTransformForMagnetize.transform.position;
        puzzleTile.IsFree = false;
        puzzleTile.InvokePartTileOnMeEvent();
    }


}
