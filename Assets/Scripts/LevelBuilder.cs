using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder instance = null;

    public static bool[,] PuzzleTemplate { get; private set; }
    private static IJsonParser jsonLevel;

    [SerializeField] private GameObject puzzleTile;

    void Awake()
    {
        //singleton
        if (instance == null) 
            instance = this;
        else if (instance == this)
            Destroy(gameObject);

        jsonLevel = Factory.CreateJsonParser("Level2");
    }

    private void Start()
    {
        PuzzleTemplate = jsonLevel.GetTemplate();
        FillPuzzleAreaFromTemplate();
        CreatePuzzleParts();
    }

    private void FillPuzzleAreaFromTemplate() {
        var puzzleArea = GameObject.FindGameObjectWithTag("PuzzleArea");

        foreach (bool isPuzzleTile in PuzzleTemplate)
        {
            var currentTile = Instantiate(puzzleTile, puzzleArea.transform);
            if (isPuzzleTile) 
            {
                currentTile.AddComponent<PuzzleTile>();
            }
        }
    }

    private void CreatePuzzleParts()
    {
        var puzzlePartContainers = GameObject.FindGameObjectsWithTag("PartContainer");
        var puzzleParts = jsonLevel.GetParts();

        for (int i = 0; i < puzzleParts.Count; i++)
        {
            CreatePuzzlePart(puzzleParts[i], puzzlePartContainers[i]);
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
                    var tileRectTransform = tile.GetComponent<RectTransform>();
                    tileRectTransform.anchoredPosition = new Vector2(50 + (100 * j), -50 - (100 * i));
                    tileRectTransform.anchorMin = new Vector2(0, 1);
                    tileRectTransform.anchorMax = new Vector2(0, 1);
                }
            }
        }

    }
    //Generate small massive to create figure
    private bool[,] RemoveExcessTiles(bool[,] templateOfFugure)
    {
        int leftmost = 3;
        int rightmost = 0;
        int highest = 3;
        int lowest = 0;
        //Find highest leftmost point of the figure and lowest rightmost point at part template from json file to rewrite massive
        for (int i = 0; i < templateOfFugure.GetLength(0); i++)
        {
            for (int j = 0; j < templateOfFugure.GetLength(1); j++)
            {
                if (templateOfFugure[i, j])
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
        bool[,] PuzzlePartTemplate = new bool[rectangeHeight + 1, rectangeWidth + 1];
        for (int i = highest; i <= lowest; i++)
        {
            for (int j = leftmost; j <= rightmost; j++)
            {
                if (templateOfFugure[i, j])
                {
                    PuzzlePartTemplate[i - highest, j - leftmost] = true;
                }
                else
                {
                    PuzzlePartTemplate[i - highest, j - leftmost] = false;
                }

            }
        }
        return PuzzlePartTemplate;
    }

    //instantiate paryBody gameobject where we put part tiles
    private GameObject CreatePuzzlePartBody(GameObject partContainer, bool[,] figureInRectangle)
    {
        Vector2 sizeFirgure = new Vector2(figureInRectangle.GetLength(1) * 100, figureInRectangle.GetLength(0) * 100);
        GameObject partBody = Instantiate(new GameObject("partBody"), partContainer.transform);
        partBody.AddComponent<PartBody>();

        partBody.GetComponent<RectTransform>().sizeDelta = sizeFirgure;
        partBody.GetComponent<BoxCollider2D>().size = sizeFirgure;

        return partBody;
    }
}
