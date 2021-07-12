using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PartBody : MonoBehaviour
{
    public List<Collider2D> childTilesCollider2DComponents = new List<Collider2D>();

    private void Awake()
    {
        ReturnToStartPosition();
    }

    public void ReturnToStartPosition() 
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
    }

    public void SwitchStateOfRigidBodiesInChildTiles() {
        foreach (var partTileRigidBody in childTilesCollider2DComponents) 
        {
            partTileRigidBody.enabled = !partTileRigidBody.enabled;
        }
    }
}
