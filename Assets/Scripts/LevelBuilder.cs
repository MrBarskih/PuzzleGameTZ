using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder instance = null;

    public static bool[,] PuzzleTemplate { get; private set; }
    private static IJsonParser jsonLevel;

    [SerializeField] private GameObject tile;

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
        fillPuzzleAreaFromTemplate();
    }

    static void Update()
    {
        
    }

    private void fillPuzzleAreaFromTemplate() {
        var puzzleArea = GameObject.FindGameObjectWithTag("PuzzleArea");

        foreach (bool templateTile in PuzzleTemplate)
        {
            var currentTile = Instantiate(tile, puzzleArea.transform);
            if (templateTile) 
            {
                currentTile.AddComponent<TemplateTile>();
            }
        }
    }
}
