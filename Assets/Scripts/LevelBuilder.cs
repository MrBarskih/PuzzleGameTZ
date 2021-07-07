using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private GameObject idleTile;
    [SerializeField] GameObject puzzleArea;

    public static LevelBuilder Instance = null;
    public static bool[,] PuzzleTemplate { get; private set; }

    private static IJsonParser jsonLevel;
    

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        jsonLevel = Factory.CreateJsonParser("Level1");
    }

    private void Start()
    {
        PuzzleTemplate = jsonLevel.GetTemplate();
        FillPuzzleAreaFromTemplate(PuzzleTemplate);

        var puzzlePartTemplates = jsonLevel.GetParts();
        var puzzlePartContainers = GameObject.FindGameObjectsWithTag("PartContainer");
        for (int i = 0; i < puzzlePartTemplates.Count; i++)
        {
            CreatePuzzlePart(puzzlePartTemplates[i], puzzlePartContainers[i]);
        }
    }

    private void FillPuzzleAreaFromTemplate(bool[,] puzzleTemplate) 
    {
        foreach (bool isPuzzleTile in puzzleTemplate)
        {
            var currentTile = Instantiate(idleTile, puzzleArea.transform);
            if (isPuzzleTile) 
            {
                currentTile.AddComponent<PuzzleTile>();
            }
        }
    }

    private void CreatePuzzlePart(bool[,] puzzlePartTemplate, GameObject puzzlePartContainer)
    {
        var puzzlePartBody = CreatePuzzlePartBody(puzzlePartContainer, puzzlePartTemplate);

        for (int i = 0; i < puzzlePartTemplate.GetLength(0); i++)
        {
            for (int j = 0; j < puzzlePartTemplate.GetLength(1); j++)
            {
                if (puzzlePartTemplate[i, j])
                {
                    var tile = Instantiate(idleTile, puzzlePartBody.transform);
                    tile.AddComponent<PartTile>();
                    tile.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 + (100 * j), -50 - (100 * i));
                }
            }
        }

    }  

    //instantiate partBody gameobject where we put part tiles
    private GameObject CreatePuzzlePartBody(GameObject partContainer, bool[,] puzzlePartTemplate)
    {
        Vector2 puzzlePartSize = new Vector2(puzzlePartTemplate.GetLength(1) * 100, puzzlePartTemplate.GetLength(0) * 100);
        GameObject partBody = new GameObject("partBody");
        partBody.AddComponent<PartBody>();
        partBody.GetComponent<RectTransform>().sizeDelta = puzzlePartSize;
        partBody.transform.SetParent(partContainer.transform, false);
        partBody.GetComponent<BoxCollider2D>().size = puzzlePartSize;

        return partBody;
    }
}
