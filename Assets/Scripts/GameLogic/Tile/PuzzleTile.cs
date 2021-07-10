using UnityEngine;

public class PuzzleTile : BaseTile
{
    public delegate void TileStateHandler(GameObject gameObject);
    public event TileStateHandler PartTileOnMe;
    public event TileStateHandler ImFree;
    public int[][] myPositionXY;


    new private void Awake()
    {
        base.Awake();  
    }

    new private void Start()
    {
        base.Start();
        imageCompanent.color = new Color32(194, 255, 131, 255);//green
    }

    private void OnTriggerEnter2D()
    {
        PartTileOnMe?.Invoke(gameObject);
    }

    private void OnTriggerExit2D()
    {
        ImFree?.Invoke(gameObject);
    }
}
