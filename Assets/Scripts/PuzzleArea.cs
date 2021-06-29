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
        IJsonParser jsonParser = Factory.CreateJsonParser("Level1");
        template = jsonParser.GetTemplate();
    }

    private void Start()
    {
        CreatePuzzleArea(template);
    }

    private void CreatePuzzleArea(bool[,] template) 
    {
        foreach(bool i in template)
        {
            var currentTile = Instantiate(tile, gameObject.transform).AddComponent<TemplateTile>();
        }
    }
}
