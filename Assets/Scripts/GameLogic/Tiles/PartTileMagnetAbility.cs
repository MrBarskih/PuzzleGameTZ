using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PartTileMagnetAbility : MonoBehaviour
{
    public  bool        IsAbleToMagnetize;
    public  Transform   puzzleTileTransformForMagnetize;

    private PuzzleTile  targetTile;
    private bool        isLanded = false;

    private void OnTriggerEnter2D(Collider2D puzzleTileCollider)
    {
        if (puzzleTileCollider.TryGetComponent(out targetTile))
        {
            if (targetTile.IsFree)
            {
                IsAbleToMagnetize = true;
                puzzleTileTransformForMagnetize = targetTile.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D puzzleTileCollider) 
    {
        if (isLanded)
        {
            IsAbleToMagnetize = false;
            targetTile.IsFree = true;
            targetTile.InvokeImFreeEvent();
            isLanded = false;
        }  
    }

    public void MagnetizeToPuzzleTile()
    {
        targetTile.IsFree = false;
        targetTile.InvokePartTileOnMeEvent();
        isLanded = true;
    }
}
