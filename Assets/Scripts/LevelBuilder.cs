using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder Instance = null;

    public static bool[,] PuzzleTemplate { get; private set; }
    private static IJsonParser jsonLevel;

    [SerializeField] private GameObject puzzleTile;

    void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        jsonLevel = Factory.CreateJsonParser("Level1");
    }

    private void Start()
    {
        FillPuzzleAreaFromTemplate();

        var puzzlePartTemplates = jsonLevel.GetParts();
        var puzzlePartContainers = GameObject.FindGameObjectsWithTag("PartContainer");
        for (int i = 0; i < puzzlePartTemplates.Count; i++)
        {
            CreatePuzzlePart(puzzlePartTemplates[i], puzzlePartContainers[i]);
        }
    }

    private void FillPuzzleAreaFromTemplate() 
    {
        GameObject puzzleArea = GameObject.FindGameObjectWithTag("PuzzleArea");
        PuzzleTemplate = jsonLevel.GetTemplate();

        foreach (bool isPuzzleTile in PuzzleTemplate)
        {
            var currentTile = Instantiate(puzzleTile, puzzleArea.transform);
            if (isPuzzleTile) 
            {
                currentTile.AddComponent<PuzzleTile>();
            }
        }
    }

    private void CreatePuzzlePart(bool[,] puzzlePartTemplate, GameObject puzzlePartContainer)
    {
        var smallerPartTemplate = RemoveExcessTiles(puzzlePartTemplate);

        var puzzlePartBody = CreatePuzzlePartBody(puzzlePartContainer, smallerPartTemplate);

        for (int i = 0; i < smallerPartTemplate.GetLength(0); i++)
        {
            for (int j = 0; j < smallerPartTemplate.GetLength(1); j++)
            {
                if (smallerPartTemplate[i, j])
                {
                    var tile = Instantiate(puzzleTile, puzzlePartBody.transform);
                    tile.AddComponent<PartTile>();
                    tile.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 + (100 * j), -50 - (100 * i));
                }
            }
        }

    }
    //Generate small massive to create puzzle part
    private bool[,] RemoveExcessTiles(bool[,] puzzlePartTemplate)
    {
        int leftmost = 3;
        int rightmost = 0;
        int highest = 3;
        int lowest = 0;
        //Find highest leftmost point of the part and lowest rightmost point at part template from json file to rewrite massive
        for (int i = 0; i < puzzlePartTemplate.GetLength(0); i++)
        {
            for (int j = 0; j < puzzlePartTemplate.GetLength(1); j++)
            {
                if (puzzlePartTemplate[i, j])
                {
                    if (i < highest) highest = i;
                    if (i > lowest) lowest = i;
                    if (j > rightmost) rightmost = j;
                    if (j < leftmost) leftmost = j;
                }

            }
        }
        //rewrite from bool[4,4] massive to a smaller massive to create a figure
        int rectangeWidth = rightmost - leftmost;
        int rectangeHeight = lowest - highest;
        bool[,] smallerPuzzlePartTemplate = new bool[rectangeHeight + 1, rectangeWidth + 1];
        for (int i = highest; i <= lowest; i++)
        {
            for (int j = leftmost; j <= rightmost; j++)
            {
                if (puzzlePartTemplate[i, j])
                {
                    smallerPuzzlePartTemplate[i - highest, j - leftmost] = true;
                }
                else
                {
                    smallerPuzzlePartTemplate[i - highest, j - leftmost] = false;
                }

            }
        }
        return smallerPuzzlePartTemplate;
    }

    //instantiate partBody gameobject where we put part tiles
    private GameObject CreatePuzzlePartBody(GameObject partContainer, bool[,] smallerPuzzlePartTemplate)
    {
        Vector2 puzzlePartSize = new Vector2(smallerPuzzlePartTemplate.GetLength(1) * 100, smallerPuzzlePartTemplate.GetLength(0) * 100);
        GameObject partBody = new GameObject("partBody");
        partBody.AddComponent<PartBody>();
        partBody.GetComponent<RectTransform>().sizeDelta = puzzlePartSize;
        partBody.transform.SetParent(partContainer.transform, false);
        partBody.GetComponent<BoxCollider2D>().size = puzzlePartSize;

        return partBody;
    }
}
