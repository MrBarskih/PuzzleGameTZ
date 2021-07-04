using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder instance = null;

    public static bool[,] PuzzleTemplate { get; private set; }
    private static IJsonParser jsonLevel;

    void Awake()
    {
        //singleton
        if (instance == null) 
            instance = this;
        else if (instance == this)
            Destroy(gameObject);

        jsonLevel = Factory.CreateJsonParser("Level1");
    }

    private void Start()
    {
        PuzzleTemplate = jsonLevel.GetTemplate();
    }

    static void Update()
    {
        
    }

    private static void fillPuzzleAreaFromTemplate() { 
    
    }
}
