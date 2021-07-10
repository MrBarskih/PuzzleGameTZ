using UnityEngine;

public class PuzzleAreaFiller : MonoBehaviour
{
    [SerializeField] private LevelDataFromJson levelData;
    [SerializeField] private GameObject puzzleArea;
    [SerializeField] private GameObject idleTile;

    private void Start()
    {
        var puzzleTemplate = levelData.PuzzleTemplate;

        if (puzzleTemplate != null)
        {
            foreach (bool isPuzzleTile in puzzleTemplate)
            {
                var currentTile = Instantiate(idleTile, puzzleArea.transform);
                if (isPuzzleTile)
                {
                    currentTile.AddComponent<PuzzleTile>()
                    
                }
            }
        }
    }
}
