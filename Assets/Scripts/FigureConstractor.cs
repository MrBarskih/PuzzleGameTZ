using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigureConstractor : MonoBehaviour
{
    [SerializeField] private GameObject puzzleTile;
    private List<bool[,]> puzzlePartTemplates;
    private GameObject[] puzzlePartContainers;
    private IJsonParser jsonLevel;

    private void Awake()
    {
        puzzlePartContainers = GameObject.FindGameObjectsWithTag("PartContainer");
        jsonLevel = Factory.CreateJsonParser("Level1");
        puzzlePartTemplates = jsonLevel.GetParts();

        for (int i = 0; i < puzzlePartTemplates.Count; i++)
        {
            CreatePuzzlePart(puzzlePartTemplates[i], puzzlePartContainers[i]);
        }
    }


    private void CreatePuzzlePart(bool[,] puzzlePartTemplate, GameObject partContainer)
    {
        var smallerPartTemplate = RemoveExcessTiles(puzzlePartTemplate);

        var partBody = CreatePuzzlePartBody(partContainer, smallerPartTemplate);

        for (int i = 0; i < smallerPartTemplate.GetLength(0); i++)
        {
            for (int j = 0; j < smallerPartTemplate.GetLength(1); j++)
            {
                if (smallerPartTemplate[i, j])
                {
                    var tile = Instantiate(puzzleTile, partBody.transform);
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
