using System.Collections.Generic;
using UnityEngine;

//(PuzzleTile lies in PuzzlePartBody)PuzzlePart that lies at PuzzlePartContainer
//PuzzlePart->(PuzzlePartBody + PuzzlePartTiles)
public class PuzzlePartCreator : MonoBehaviour
{
    [SerializeField] private LevelDataFromJson levelData;
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
        var puzzlePartBodyMagnetComponent = puzzlePartBody.GetComponent<PartBodyMagnet>();

        for (int i = 0; i < puzzlePartTemplate.Length; i++)
        {
            for (int j = 0; j < puzzlePartTemplate[i].Length; j++)
            {
                if (puzzlePartTemplate[i][j])
                {
                    var partTile = Instantiate(partTilePrefab, puzzlePartBody.transform);
                    puzzlePartBodyMagnetComponent.ChildTilesMagnetAbilityComponents.Add(partTile.GetComponent<PartTileMagnetAbility>());
                    partTile.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 + (100 * j), -50 - (100 * i));
                }
            }
        }
    }

    private GameObject CreatePuzzlePartBody(GameObject partContainer, bool[][] puzzlePartTemplate)
    {
        GameObject partBody = new GameObject("partBody");

        Vector2 puzzlePartSize = new Vector2(puzzlePartTemplate[0].Length * 100, puzzlePartTemplate.Length * 100);

        partBody.AddComponent<PartBodyMagnet>();
        partBody.GetComponent<RectTransform>().sizeDelta = puzzlePartSize;
        partBody.transform.SetParent(partContainer.transform, false);

        return partBody;
    }
}
