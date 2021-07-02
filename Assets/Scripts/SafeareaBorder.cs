using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeareaBorder : MonoBehaviour
{
    private ScreenOrientation currentScreenOrientation;

    void Update()
    {
        if (Screen.orientation != currentScreenOrientation)
        {
            currentScreenOrientation = Screen.orientation;
            CalculateSafeAreaBorders();
        }

    }

    public void CalculateSafeAreaBorders()
    {
        var safeAreaRectTransform = gameObject.GetComponent<RectTransform>();

        var anchorMin = Screen.safeArea.position;
        var anchorMax = anchorMin + Screen.safeArea.size;

        anchorMin.x /= Screen.currentResolution.width;
        anchorMin.y /= Screen.currentResolution.height;
        anchorMax.x /= Screen.currentResolution.width;
        anchorMax.y /= Screen.currentResolution.height;

        safeAreaRectTransform.anchorMin = anchorMin;
        safeAreaRectTransform.anchorMax = anchorMax;
    }
}
