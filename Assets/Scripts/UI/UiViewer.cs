using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class UiViewer : MonoBehaviour
{
    [SerializeField] private PuzzleAreaObserver puzzleAreaObserver;
    [SerializeField] private GameObject puzzleArea;
    [SerializeField] private GameObject winConditionWindow;
    [SerializeField] private List<GameObject> puzzleParts = new List<GameObject>();

    private void Awake()
    {
        if (puzzleAreaObserver != null)
        {
            puzzleAreaObserver.LevelIsComplited += ShowWinConditionWindow;
            puzzleAreaObserver.LevelIsComplited += HidePuzzleArea;
            puzzleAreaObserver.LevelIsComplited += HidePuzzleParts;
        }
        else
        {
            throw new UnityException("PuzzleAreaObserver is equal null");
        }
    }

    private void OnDestroy()
    {
        if (puzzleAreaObserver != null)
        {
            puzzleAreaObserver.LevelIsComplited -= ShowWinConditionWindow;
            puzzleAreaObserver.LevelIsComplited -= HidePuzzleArea;
            puzzleAreaObserver.LevelIsComplited -= HidePuzzleParts;
        }
        else
        {
            throw new UnityException("PuzzleAreaObserver is equal null");
        }
    }

    private void ShowWinConditionWindow() 
    {
        if (winConditionWindow != null)
        {
            winConditionWindow.SetActive(true);
        }
        else
        {
            throw new UnityException("WinConditionWindow is equal null");
        }
    }

    private void HidePuzzleArea() 
    {
        if (puzzleArea != null)
        {
            puzzleArea.SetActive(false);
        }
        else
        {
            throw new UnityException("PuzzleArea is equal null");
        }
    }

    private void HidePuzzleParts() 
    {
        if (puzzleParts.Any())
        {
            foreach (var part in puzzleParts) 
            {
                part.SetActive(false);
            }
        }
        else
        {
            throw new UnityException("PuzzleParts are equal null");
        }
    }
}
