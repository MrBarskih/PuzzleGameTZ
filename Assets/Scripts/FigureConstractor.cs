using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigureConstractor : MonoBehaviour
{
    private IJsonParser jsonParser;

    [SerializeField]
    private GameObject puzzleTile;
    private List<bool[,]> puzzleParts;
    private GameObject[] puzzleContainers;

    private void Awake()
    {
        puzzleContainers = GameObject.FindGameObjectsWithTag("PartContainer");
        jsonParser = Factory.CreateJsonParser("Level1");
        puzzleParts = jsonParser.GetParts();

        for (int i = 0; i < puzzleParts.Count; i++)
        {
            createFigure(puzzleParts[i], puzzleContainers[i]);
        }
    }


    private void createFigure(bool[,] templateOfFugure, GameObject partContainer)
    {

        var figureInRectangle = getFigureInRectangleFromTemplate(templateOfFugure);

        var partBody = createPartBody(partContainer, figureInRectangle);

        for (int i = 0; i < figureInRectangle.GetLength(0); i++)
        {
            for (int j = 0; j < figureInRectangle.GetLength(1); j++)
            {
                if (figureInRectangle[i, j])
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
    private bool[,] getFigureInRectangleFromTemplate(bool[,] templateOfFugure)
    {
        int leftmost = 3;
        int rightmost = 0;
        int highest = 3;
        int lowest = 0;
        //Find highest leftmost point of the figure and lowest rightmost point to rewrite massive
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
        bool[,] figureInRectangle = new bool[rectangeHeight + 1, rectangeWidth + 1];
        for (int i = highest; i <= lowest; i++)
        {
            for (int j = leftmost; j <= rightmost; j++)
            {
                if (templateOfFugure[i, j])
                {
                    figureInRectangle[i - highest, j - leftmost] = true;
                }
                else
                {
                    figureInRectangle[i - highest, j - leftmost] = false;
                }

            }
        }
        return figureInRectangle;
    }

    //instantiate paryBody gameobject where we put figure tiles
    private GameObject createPartBody(GameObject partContainer, bool[,] figureInRectangle)
    {
        Vector2 sizeFirgure = new Vector2(figureInRectangle.GetLength(1) * 100, figureInRectangle.GetLength(0) * 100);
        GameObject partBody = Instantiate(new GameObject("partBody"), partContainer.transform);
        partBody.AddComponent<PartBody>();

        partBody.GetComponent<RectTransform>().sizeDelta = sizeFirgure;
        partBody.GetComponent<BoxCollider2D>().size = sizeFirgure;

        return partBody;
    }
}
