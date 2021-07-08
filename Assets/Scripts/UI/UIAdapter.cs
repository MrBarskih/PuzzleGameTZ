using UnityEngine;
using UnityEngine.UI;

public class UIAdapter : MonoBehaviour
{
    [SerializeField] private CanvasScaler mainCanvasScaler;
    [SerializeField] private RectTransform safeareaRectTransform;

    ScreenOrientation currentScreenOrientation = ScreenOrientation.AutoRotation;

    private void Update()
    {
        if (Screen.orientation != currentScreenOrientation)
        {
            currentScreenOrientation = Screen.orientation;
            CalculateSafeAreaBorders();
            AdjustCanvasScaler();
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

    private void AdjustCanvasScaler()
    {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            mainCanvasScaler.referenceResolution = new Vector2(1250, 2048);
            mainCanvasScaler.matchWidthOrHeight = 0f;
        }
        else
        {
            mainCanvasScaler.referenceResolution = new Vector2(1250, 1000);
            mainCanvasScaler.matchWidthOrHeight = 1f;
        }
    }
}
