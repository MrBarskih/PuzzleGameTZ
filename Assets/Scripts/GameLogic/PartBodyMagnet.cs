using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PartBodyMagnet : MonoBehaviour
{
    public List<PartTileMagnetAbility> ChildTilesMagnetAbilityComponents = new List<PartTileMagnetAbility>();

    private RectTransform rectTransformCompanent;
    private void Awake()
    {
        rectTransformCompanent = GetComponent<RectTransform>();
    }

    public void TryToMagnetize() {
        foreach (var purtTile in ChildTilesMagnetAbilityComponents)
        {
            if (!purtTile.IsAbleToMagnetize)
            {
                ReturnToStartPosition();
                return; 
            }
        }
        foreach (var partTile in ChildTilesMagnetAbilityComponents)
        {
            partTile.MagnetizeToPuzzleTile();
        }
    }

    private void ReturnToStartPosition()
    {
        rectTransformCompanent.anchoredPosition = new Vector2(0, 0);
        rectTransformCompanent.localScale = new Vector2(1, 1);
    }
}
