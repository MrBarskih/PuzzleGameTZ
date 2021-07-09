using System;
using UnityEngine;
using UnityEngine.UI;

public class UIAdapter : MonoBehaviour
{
    [Header("Components For Changing")]
    [SerializeField] private CanvasScaler canvasScaler;
    [SerializeField] private RectTransform safeareaRectTransform;
    [SerializeField] private RectTransform puzzleAreaRectTransform;

    [Header("Canvas Scaler")]
    [SerializeField] private Vector2 portraitReferenceResolution;
    [SerializeField] private Vector2 landscapeReferenceResolution;
    [SerializeField] [Range(0f, 1f)] private float portraitMatchWidthOrHeight;
    [SerializeField] [Range(0f, 1f)] private float landscapeMatchWidthOrHeight;

    [Header("Puzzle Area")]
    [SerializeField] private Vector2 portraitPuzzleAreaLocalScale;
    [SerializeField] private Vector2 landscapePuzzleAreaLocalScale;

    ScreenOrientation currentScreenOrientation = ScreenOrientation.AutoRotation;

    private void Update()
    {
        if (Screen.orientation != currentScreenOrientation)
        {
            currentScreenOrientation = Screen.orientation;

            CalculateSafeAreaBorders();

            if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {
                AdjustCanvasScaler(portraitReferenceResolution, portraitMatchWidthOrHeight);
                puzzleAreaRectTransform.localScale = portraitPuzzleAreaLocalScale;
            }
            else
            {
                AdjustCanvasScaler(landscapeReferenceResolution, landscapeMatchWidthOrHeight);
                puzzleAreaRectTransform.localScale = landscapePuzzleAreaLocalScale;
            }
        }
    }

    private void AdjustCanvasScaler(Vector2 referenceResolution, float matchWidthOrHeight)
    {
        canvasScaler.referenceResolution = referenceResolution;
        canvasScaler.matchWidthOrHeight = matchWidthOrHeight;
    }

    private void CalculateSafeAreaBorders()
    {
        var anchorMin = Screen.safeArea.position;
        var anchorMax = anchorMin + Screen.safeArea.size;

        anchorMin.x /= Screen.currentResolution.width;
        anchorMin.y /= Screen.currentResolution.height;
        anchorMax.x /= Screen.currentResolution.width;
        anchorMax.y /= Screen.currentResolution.height;

        safeareaRectTransform.anchorMin = anchorMin;
        safeareaRectTransform.anchorMax = anchorMax;
    }
}
