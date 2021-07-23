using System.Collections.Generic;
using UnityEngine;

public class PartBodyMagnet : MonoBehaviour
{
    public List<PartTileMagnetAbility> ChildTilesMagnet = new List<PartTileMagnetAbility>();

    public bool IsInPuzzleArea = false;
    public Transform FirstParent;

    private RectTransform rectTransformCompanent;
    private bool shouldGoToStartPosition = false;

    private void Awake()
    {
        rectTransformCompanent = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (shouldGoToStartPosition)
        {
            rectTransformCompanent.anchoredPosition = Vector2.MoveTowards(rectTransformCompanent.anchoredPosition, Vector2.zero, 40f);
            if (rectTransformCompanent.anchoredPosition == new Vector2(0, 0)) 
            {
                shouldGoToStartPosition = false;
            }
        }
    }

    public void TryToMagnetize() {

        if (ChildTilesMagnet == null)
        {
            throw new UnityException("There is no tiles in the part puzzle");    
        }

        foreach (var purtTile in ChildTilesMagnet)
        {
            if (!purtTile.IsAbleToMagnetize)
            {
                ReturnToStartPosition();
                return; 
            }
        }

        transform.SetParent(GameObject.Find("PuzzleArea").transform);

        foreach (var partTile in ChildTilesMagnet)
        {
            partTile.MagnetizeToPuzzleTile();
        }

        MagnetizeToPuzzleArea();

        IsInPuzzleArea = true;
    }

    private void ReturnToStartPosition()
    {
        transform.SetParent(FirstParent);
        shouldGoToStartPosition = true;
        rectTransformCompanent.localScale = new Vector2(1, 1);
        IsInPuzzleArea = false;
    }

    public void MagnetizeToPuzzleArea() 
    {
        var puzzleTilePosition = ChildTilesMagnet[0].puzzleTileTransformForMagnetize.position;

        float puzzleTileRightmostX = puzzleTilePosition.x;
        float puzzleTileLeftmostmostX = puzzleTilePosition.x;

        float puzzleTilUppestY = puzzleTilePosition.y;
        float puzzleTileLowestY = puzzleTilePosition.y;

        foreach (var child in ChildTilesMagnet)
        {
            var puzzlePosition = child.puzzleTileTransformForMagnetize.position;
            if (puzzlePosition.x < puzzleTileLeftmostmostX)
            {
                puzzleTileLeftmostmostX = puzzlePosition.x;
            }
            if (puzzlePosition.x > puzzleTileRightmostX)
            {
                puzzleTileRightmostX = puzzlePosition.x;
            }
            if (puzzlePosition.y < puzzleTileLowestY)
            {
                puzzleTileLowestY = puzzlePosition.y;
            }
            if (puzzlePosition.y > puzzleTilUppestY)
            {
                puzzleTilUppestY = puzzlePosition.y;
            }
        }
        var averageXPosition = (puzzleTileLeftmostmostX + puzzleTileRightmostX) / 2;
        var averageYPosition = (puzzleTilUppestY + puzzleTileLowestY) / 2;

        var position = transform.position;
        position.x = averageXPosition;
        position.y = averageYPosition;
        transform.position = position;
    }
}
