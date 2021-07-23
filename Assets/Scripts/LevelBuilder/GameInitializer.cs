using UnityEngine;
using System.Collections.Generic;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private string fileName;
    [SerializeField] private LevelDataFromJson levelData;

    private static IJsonParser jsonLevel;
    
    private void Awake()
    {
        jsonLevel = Factory.CreateJsonParser($"{fileName}");

        if (jsonLevel != null)
        {
            levelData.LevelName = fileName;
            levelData.PuzzleTemplate = jsonLevel?.GetTemplate();
            levelData.PuzzlePartsTemplates = jsonLevel?.GetParts();
        }
    }
}
