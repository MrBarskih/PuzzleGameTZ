using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(RectTransform))]
public class PartBody : MonoBehaviour
{
    public List<Collider2D> childTilesCollider2DComponents = new List<Collider2D>();

    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        ReturnToStartPosition();
    }

    public void ReturnToStartPosition() 
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
    }

    public void SwitchStatOfChildTilesRigidBodies() {
        foreach (var partTileRigidBody in childTilesCollider2DComponents) 
        {
            partTileRigidBody.enabled = !partTileRigidBody.enabled;
        }
    }
}
