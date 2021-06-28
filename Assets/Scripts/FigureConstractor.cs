using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigureConstractor : MonoBehaviour
{
    private IJsonParser jsonParser;

    List<bool[,]> parts = new List<bool[,]>();

    [SerializeField]
    private Tile tilePrefab;

    void Awake()
    {
        jsonParser = Factory.CreateJsonParser("Level1");
        parts = jsonParser.GetParts();
    }
    private void Start()
    {
        foreach (bool[,] value in parts)
        {
            var part = Instantiate(new GameObject("part"), gameObject.transform);
            part.AddComponent<ContentSizeFitter>();
            for (int i = 0; i < value.GetLength(0); i++)
            {
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    if(value[i,j])
                    {
                        
                        var tile = Instantiate(tilePrefab, part.transform);
                    }
                        
                }
            }    
        }
    }
}
