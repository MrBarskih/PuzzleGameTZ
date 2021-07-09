using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelDataFromJson : ScriptableObject
{
    public string LevelName;
    public bool[,] PuzzleTemplate;
    public List<bool[,]> PuzzleParts;
}
