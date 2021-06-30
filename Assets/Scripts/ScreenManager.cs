using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    private ScreenOrientation currentOrientation;
    private RectTransform safeAreaPanelRectTransform;
    private Vector2 anchorMin;
    private Vector2 anchorMax;
    private Dictionary<string, RectTransform> safeAreaElements = 
        new Dictionary<string, RectTransform>(); 

    private void Awake()
    {
        currentOrientation = Screen.orientation;
        safeAreaPanelRectTransform = gameObject.GetComponent<RectTransform>();

        //Find all objects on scene with tag "SafeAreaElement"
            foreach (RectTransform child in transform)
            {
                safeAreaElements.Add(child.name, child.GetComponent<RectTransform>());
            }

        if (currentOrientation == ScreenOrientation.Portrait)
        {
            anchorMin = Screen.safeArea.position;
            anchorMax = anchorMin + Screen.safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            safeAreaPanelRectTransform.anchorMin = anchorMin;
            safeAreaPanelRectTransform.anchorMax = anchorMax;
        }
        else if (currentOrientation == ScreenOrientation.Landscape)
        {

        }

        
    }

}
