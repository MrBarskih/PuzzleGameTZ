using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleAreaObserver : MonoBehaviour
{
    [SerializeField] private LevelDataFromJson levelData;

    private bool[][] currentPuzzleProgress;

    private void Start()
    {
        currentPuzzleProgress = new bool[levelData.PuzzleTemplate.Length][];
        for (int i = 0; i < currentPuzzleProgress.Length; i++)
        {
            currentPuzzleProgress[i] = new bool[levelData.PuzzleTemplate[0].Length];
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
        currentPuzzleProgress[puzzleTileRow][puzzletileColumn] = true;
        CheckWinCondition();
    }

    private void SetFalse(int puzzleTileRow, int puzzletileColumn)
    {
        currentPuzzleProgress[puzzleTileRow][puzzletileColumn] = false;
    }

    private void CheckWinCondition() 
    {
        for (int i = 0; i < currentPuzzleProgress.Length; i++)
        {
            for (int j = 0; j < currentPuzzleProgress[i].Length; j++)
            {
                if (currentPuzzleProgress[i][j] != levelData.PuzzleTemplate[i][j])
                {
                    return;
                }
            }
        }
        Debug.Log("PuzzleComplete");
    }
}
