using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class PartBodyMagnet : MonoBehaviour
{
    public List<PartTileMagnetAbility> ChildTilesMagnetAbilityComponents = new List<PartTileMagnetAbility>();

    private RectTransform rectTransformCompanent;
    private bool ShouldGoToStartPosition = false;
    private void Awake()
    {
        rectTransformCompanent = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (ShouldGoToStartPosition)
        {
            rectTransformCompanent.anchoredPosition = Vector2.MoveTowards(rectTransformCompanent.anchoredPosition, Vector2.zero, 40f);
            if (rectTransformCompanent.anchoredPosition == new Vector2(0, 0)) 
            {
                ShouldGoToStartPosition = false;
            }
        }
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
        ShouldGoToStartPosition = true;
        rectTransformCompanent.localScale = new Vector2(1, 1);
    }
}
