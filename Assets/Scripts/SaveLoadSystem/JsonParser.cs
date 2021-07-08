using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

public class JsonParser : IJsonParser
{
    private JObject jsonFileStructure;

    public JsonParser(string level)
    {
        TextAsset levelFile = Resources.Load($"{level}") as TextAsset;
        jsonFileStructure = JObject.Parse(levelFile.ToString());
    }

    public List<bool[,]> GetParts()
    {
        List<bool[,]> result = new List<bool[,]>();

        foreach (JToken value in jsonFileStructure.GetValue("parts"))
        {
            var puzzlePartTemplate = RemoveExcessTiles(value.ToObject<bool[,]>());
            result.Add(puzzlePartTemplate);
        }

        return result;
    }

    public bool[,] GetTemplate()
    {
        bool[,] result = jsonFileStructure.GetValue("template").ToObject<bool[,]>();

        return result;
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
}
