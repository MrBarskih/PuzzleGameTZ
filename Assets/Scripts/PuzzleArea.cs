using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleArea : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    private bool[,] template;
    void Awake()
    {
        IJsonParser jsonParser = Factory.CreateJsonParser("Level2");
        template = jsonParser.GetTemplate();
    }

    private void Start()
    {
        CreatePuzzleArea(template);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatePuzzleArea(bool[,] template) 
    {
        foreach(bool i in template)
        {
            var currentTile = Instantiate(tile, gameObject.transform).GetComponent<Tile>();
            currentTile.IsPartOfTemplate = i;      
        }
    }
}