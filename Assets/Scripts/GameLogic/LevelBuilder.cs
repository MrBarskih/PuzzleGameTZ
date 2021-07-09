using UnityEngine;
using System.Collections.Generic;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private string fileName;
    [SerializeField] private GameObject idleTile;
    [SerializeField] private GameObject puzzleArea;
    [SerializeField] private List<GameObject> puzzlePartContainers = new List<GameObject>();
    [SerializeField] private LevelDataFromJson levelData;

    private static IJsonParser jsonLevel;
    
    private void Awake()
    {
        jsonLevel = Factory.CreateJsonParser($"{fileName}");
    }

    private void Start()
    {
        levelData.LevelName = fileName;

        levelData.PuzzleTemplate = jsonLevel.GetTemplate();
        levelData.PuzzleParts = jsonLevel.GetParts();
        
        var puzzleTemplate = jsonLevel.GetTemplate();

        if (puzzleTemplate != null)
        {
            FillPuzzleAreaFromTemplate(puzzleTemplate);
        }

        var puzzlePartTemplates = jsonLevel.GetParts();
        if (puzzlePartTemplates != null)
        {
            for (int i = 0; i < puzzlePartTemplates.Count; i++)
            {
                CreatePuzzlePart(puzzlePartTemplates[i], puzzlePartContainers[i]);
            }
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
