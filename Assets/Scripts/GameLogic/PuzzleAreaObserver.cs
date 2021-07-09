using UnityEngine;

public class PuzzleAreaObserver : MonoBehaviour
{
    private bool[,] puzzleTemplate;

    private void Start()
    {
    }

    private void GetPuzzleTemplate(bool[,] puzzleTemplate) 
    {
        this.puzzleTemplate = puzzleTemplate;
    }
}
