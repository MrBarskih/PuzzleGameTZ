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
            for (int i = 0; i < puzzleTemplate.Length; i++)
            {
                for (int j = 0; j < puzzleTemplate[i].Length; j++)
                {
                    var currentTile = Instantiate(idleTile, puzzleArea.transform);
                    if (puzzleTemplate[i][j])
                    {
                        var puzzleTileComponent = currentTile.AddComponent<PuzzleTile>();
                        puzzleTileComponent.puzzleAreaColumnPosition = j;
                        puzzleTileComponent.puzzleAreaRowPosition = i;
                    }
                }
            }
        }
    }
}
