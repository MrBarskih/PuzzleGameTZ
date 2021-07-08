using UnityEngine;

public class SafeareaBorder : MonoBehaviour
{
    private ScreenOrientation currentScreenOrientation;

    private void Update()
    {
        if (Screen.orientation != currentScreenOrientation)
        {
            currentScreenOrientation = Screen.orientation;
            CalculateSafeAreaBorders();
        }

    }

    public void CalculateSafeAreaBorders()
    {
        var rectTransformCompanent = GetComponent<RectTransform>();

        var anchorMin = Screen.safeArea.position;
        var anchorMax = anchorMin + Screen.safeArea.size;

        anchorMin.x /= Screen.currentResolution.width;
        anchorMin.y /= Screen.currentResolution.height;
        anchorMax.x /= Screen.currentResolution.width;
        anchorMax.y /= Screen.currentResolution.height;

        rectTransformCompanent.anchorMin = anchorMin;
        rectTransformCompanent.anchorMax = anchorMax;
    }
}
