using System.Collections.Generic;
using UnityEngine;

//(PuzzleTile lies in PuzzlePartBody)PuzzlePart that lies at PuzzlePartContainer
//PuzzlePart->(PuzzlePartBody + PuzzlePartTiles)
public class PuzzlePartCreator : MonoBehaviour
{
    [SerializeField] private LevelDataFromJson levelData;

    [Header("Tiles")]
    [SerializeField] private GameObject idleTilePrefab;
    [SerializeField] private GameObject partTilePrefab;

    [SerializeField] private List<GameObject> puzzlePartContainers = new List<GameObject>();

    private void Start()
    {
        var puzzlePartsTemplates = levelData.PuzzlePartsTemplates;

        if (puzzlePartsTemplates != null)
        {
            for (int i = 0; i < puzzlePartsTemplates.Count; i++)
            {
                CreatePuzzlePart(puzzlePartsTemplates[i], puzzlePartContainers[i]);
            }
        }
    }

    private void CreatePuzzlePart(bool[][] puzzlePartTemplate, GameObject puzzlePartContainer)
    {
        var puzzlePartBody = CreatePuzzlePartBody(puzzlePartContainer, puzzlePartTemplate);
        InsertPartTiles(puzzlePartTemplate, puzzlePartBody);
    }

    private GameObject CreatePuzzlePartBody(GameObject partContainer, bool[][] puzzlePartTemplate)
    {
        GameObject partBody = new GameObject("partBody");

        float width = puzzlePartTemplate[0].Length * 100;
        float height = puzzlePartTemplate.Length * 100;

        PartBodyInitializer.CreateComponent(partBody, partContainer.transform, height, width);

        return partBody;
    }

    private void InsertPartTiles(bool[][] puzzlePartTemplate, GameObject puzzlePartBody)
    {
        for (int i = 0; i < puzzlePartTemplate.Length; i++)
        {
            for (int j = 0; j < puzzlePartTemplate[i].Length; j++)
            {
                if (puzzlePartTemplate[i][j])
                {
                    var partTile = Instantiate(partTilePrefab, puzzlePartBody.transform);
                    partTile.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 + (100 * j), -50 - (100 * i));

                    var puzzlePartBodyMagnetComponent = puzzlePartBody.GetComponent<PartBodyMagnet>();
                    puzzlePartBodyMagnetComponent.ChildTilesMagnet.Add(partTile.GetComponent<PartTileMagnetAbility>());
                }
            }
        }
    }
}