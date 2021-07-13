using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PartTileMagnetAbility : MonoBehaviour
{
    public bool IsAbleToMagnetize;

    private PuzzleTile target;
    private Transform targetTransformForMagnetize;

    public void MagnetizeToPuzzleTile()
    {
        gameObject.transform.position = targetTransformForMagnetize.transform.position;
        target.IsFree = false;
        target.InvokePartTileOnMeEvent();
    }

    private void OnTriggerEnter2D(Collider2D puzzleTileCollider)
    {
        if (puzzleTileCollider.TryGetComponent(out target))
        {
            if (target.IsFree)
            {
                IsAbleToMagnetize = true;
                targetTransformForMagnetize = target.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D puzzleTileCollider) 
    {
        if (puzzleTileCollider.transform == targetTransformForMagnetize) 
        {
            IsAbleToMagnetize = false;
            target.IsFree = true;
            target.InvokeImFreeEvent();
        }
    }

    private void Awake()
    {
        gameObject.transform.parent.GetComponent<PartBodyMagnet>().ChildTilesMagnetAbilityComponents.Add(this);
    }
}
