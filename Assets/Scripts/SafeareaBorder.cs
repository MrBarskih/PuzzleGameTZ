using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeareaBorder : MonoBehaviour
{
    private GameObject mainCanvas;

    private Dictionary<string, RectTransform> safeAreaElements =
        new Dictionary<string, RectTransform>();

    private void Awake()
    {
        mainCanvas = GameObject.FindGameObjectWithTag("Canvas");

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("SafeAreaElement"))
        {
            safeAreaElements.Add(item.transform.name, item.GetComponent<RectTransform>());
        }
    }
    private void Start()
    {
        safeAreaElements["MainContent"].anchorMax = new Vector2
            (safeAreaElements["MainContent"].anchorMax.x,
            1 - (safeAreaElements["Header"].rect.height * mainCanvas.transform.localScale.y / Screen.height));

        CalculateSafeAreaBorders();
    }

    private void CalculateSafeAreaBorders()
    {
        var safeAreaRectTransform = gameObject.GetComponent<RectTransform>();
        var anchorMin = Screen.safeArea.position;
        var anchorMax = anchorMin + Screen.safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        safeAreaRectTransform.anchorMin = anchorMin;
        safeAreaRectTransform.anchorMax = anchorMax;
    }
}
