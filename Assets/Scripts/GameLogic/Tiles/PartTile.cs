using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PartTile : MonoBehaviour
{
    private void Awake()
    {
        gameObject.transform.parent.GetComponent<PartBody>().childTilesCollider2DComponents.Add(GetComponent<Collider2D>());
    }
}
