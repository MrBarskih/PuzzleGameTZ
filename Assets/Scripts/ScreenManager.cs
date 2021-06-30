using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    //Calculate the safearea of a phone
    private void Awake()
    {
        var rectTransform = gameObject.GetComponent<RectTransform>();
        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
    }

}
