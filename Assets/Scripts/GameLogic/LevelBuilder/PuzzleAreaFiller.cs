using UnityEngine;

public class PuzzleAreaFiller : MonoBehaviour
{
    [SerializeField] private LevelDataFromJson levelData;
    [SerializeField] private GameObject puzzleArea;
    [SerializeField] private GameObject idleTile;
    [SerializeField] private GameObject puzzleTile;

    private void Start()
    {
        var puzzleTemplate = levelData.PuzzleTemplate;

        if (puzzleTemplate != null)
        {
            for (int i = 0; i < puzzleTemplate.Length; i++)
            {
                for (int j = 0; j < puzzleTemplate[i].Length; j++)
                {
                    
                    if (puzzleTemplate[i][j])
                    {
                        var puzzleTileComponent = Instantiate(puzzleTile, puzzleArea.transform).GetComponent<PuzzleTileInitializer>();
                        puzzleTileComponent.puzzleAreaColumnPosition = j;
                        puzzleTileComponent.puzzleAreaRowPosition = i;
                    }
                    else
                    {
                        Instantiate(idleTile, puzzleArea.transform);
                    }
                }
            }
        }
    }
}
