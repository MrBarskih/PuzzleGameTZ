using System;
using UnityEngine;

public class PartTileMagnetAbility : MonoBehaviour
{
    public bool IsAbleToMagnetize { get; set; }
    private Collider2D targetForMagnetize;

    public void MagnetizeToPuzzleTile()
    {
        gameObject.transform.position = targetForMagnetize.transform.position;
        targetForMagnetize.GetComponent<PuzzleTileInitializer>().IsFree = false;
        targetForMagnetize.GetComponent<PuzzleTileInitializer>().InvokePartTileOnMe();
    }

    private void OnTriggerEnter2D(Collider2D puzzleTile)
    {
        if (puzzleTile.transform.GetComponent<PuzzleTileInitializer>().IsFree)
        {
            IsAbleToMagnetize = true;
            targetForMagnetize = puzzleTile;
        }
    }

    private void OnTriggerExit2D(Collider2D puzzleTile) {
        if (puzzleTile == targetForMagnetize) {
            IsAbleToMagnetize = false;
            puzzleTile.GetComponent<PuzzleTileInitializer>().IsFree = true;
            puzzleTile.GetComponent<PuzzleTileInitializer>().InvokeImFree();
        }
    }

    
}
