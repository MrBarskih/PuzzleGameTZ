using UnityEngine;
using UnityEngine.UI;

public class UIAdapter : MonoBehaviour
{
    [SerializeField] private CanvasScaler mainCanvasScaler;
    [SerializeField] private RectTransform safeareaRectTransform;
    [SerializeField] private RectTransform headerRectTransform;
    [SerializeField] private RectTransform puzzleAreaRectTransform;

    ScreenOrientation currentScreenOrientation = ScreenOrientation.AutoRotation;

    private void Update()
    {
        if (Screen.orientation != currentScreenOrientation)
        {
            currentScreenOrientation = Screen.orientation;
            CalculateSafeAreaBorders();
            if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {
                AdjustCanvasScaler(new Vector2(1650, 2048), 0f);
                puzzleAreaRectTransform.localScale = new Vector3(1.5f, 1.5f);
            }
            else
            {
                AdjustCanvasScaler(new Vector2(1650, 1200), 1f);
                puzzleAreaRectTransform.localScale = new Vector3(1f, 1f);
            }
        }
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

    private void AdjustCanvasScaler(Vector2 referenceResolution, float matchWidthOrHeight)
    {
            mainCanvasScaler.referenceResolution = referenceResolution;
            mainCanvasScaler.matchWidthOrHeight = matchWidthOrHeight;
    }
}
