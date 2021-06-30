using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    private ScreenOrientation curentOrientation;
    private RectTransform safeAreaPanelRectTransform;

    private void Awake()
    {
        curentOrientation = Screen.orientation;
        safeAreaPanelRectTransform = gameObject.GetComponent<RectTransform>();

        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        safeAreaPanelRectTransform.anchorMin = anchorMin;
        safeAreaPanelRectTransform.anchorMax = anchorMax;
    }

}
