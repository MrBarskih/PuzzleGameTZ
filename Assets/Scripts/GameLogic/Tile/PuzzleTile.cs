using UnityEngine;

public class PuzzleTile : BaseTile
{
    public delegate void TileStateHandler(int row, int column);
    public event TileStateHandler PartTileOnMe;
    public event TileStateHandler ImFree;
    public int puzzleAreaRowPosition;
    public int puzzleAreaColumnPosition;

    private Collider2D hostOfTheTile;
    private bool amIFree = true;

    new private void Awake()
    {
        base.Awake();  
    }

    new private void Start()
    {
        base.Start();
        imageCompanent.color = new Color32(194, 255, 131, 255);//green
    }

    private void OnTriggerEnter2D(Collider2D partTile)
    {
        if (amIFree)
        {
            amIFree = false;
            hostOfTheTile = partTile;
            PartTileOnMe?.Invoke(puzzleAreaRowPosition, puzzleAreaColumnPosition);
        }
    }

    private void OnTriggerExit2D(Collider2D partTile)
    {
        if (hostOfTheTile == partTile)
        {
            amIFree = true;
            ImFree?.Invoke(puzzleAreaRowPosition, puzzleAreaColumnPosition);
        }
    }
}
