using UnityEngine;
using UnityEngine.UI;

public class PuzzleTile : MonoBehaviour
{
    public delegate void TileStateHandler(int row, int column);
    public event TileStateHandler PartTileOnMe;
    public event TileStateHandler ImFree;
    public int puzzleAreaRowPosition;
    public int puzzleAreaColumnPosition;
    public bool IsFree = true;

    public void InvokePartTileOnMeEvent() 
    {
        PartTileOnMe.Invoke(puzzleAreaRowPosition, puzzleAreaColumnPosition);
    }
    public void InvokeImFreeEvent()
    {
        ImFree.Invoke(puzzleAreaRowPosition, puzzleAreaColumnPosition);
    }
}
