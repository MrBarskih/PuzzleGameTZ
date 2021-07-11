using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleAreaObserver : MonoBehaviour
{
    [SerializeField] private LevelDataFromJson levelData;

    private bool[][] curentPuzzleProgress;

    private void Start()
    {
        curentPuzzleProgress = new bool[levelData.PuzzleTemplate.Length][];
        for (int i = 0; i < curentPuzzleProgress.Length; i++)
        {
            curentPuzzleProgress[i] = new bool[levelData.PuzzleTemplate[0].Length];
        }
        for (int i = 0; i < gameObject.transform.childCount; i++) 
        {
            var puzzleTileComponent = gameObject.transform.GetChild(i).GetComponent<PuzzleTile>();
            if (puzzleTileComponent != null)
            {
                puzzleTileComponent.PartTileOnMe += SetTrue;
                puzzleTileComponent.ImFree += SetFalse;
            }
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {

            var puzzleTileComponent = gameObject.transform.GetChild(i).GetComponent<PuzzleTile>();
            if (puzzleTileComponent != null)
            {
                puzzleTileComponent.PartTileOnMe -= SetTrue;
                puzzleTileComponent.ImFree -= SetFalse;
            }
        }
    }

    private void SetTrue(int puzzleTileRow, int puzzletileColumn) 
    {
        curentPuzzleProgress[puzzleTileRow][puzzletileColumn] = true;
        CheckWinCondition();
    }

    private void SetFalse(int puzzleTileRow, int puzzletileColumn)
    {
        curentPuzzleProgress[puzzleTileRow][puzzletileColumn] = false;
    }

    private void CheckWinCondition() 
    {
        if (Enumerable.SequenceEqual(curentPuzzleProgress, levelData.PuzzleTemplate))
        {
            Debug.Log("Yeap");
        }
    }
}
