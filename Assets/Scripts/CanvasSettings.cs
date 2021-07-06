using UnityEngine.UI;
using UnityEngine;

public class CanvasSettings : MonoBehaviour
{
    CanvasScaler canvasScaler;
    ScreenOrientation currentScreeOrientation = ScreenOrientation.Portrait;
    void Awake()
    {
        canvasScaler = gameObject.GetComponent<CanvasScaler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.orientation != currentScreeOrientation)
        {
            currentScreeOrientation = Screen.orientation;
            if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {
                canvasScaler.referenceResolution = new Vector2(1250, 2048);
                canvasScaler.matchWidthOrHeight = 0f;
            }
            else
            {
                canvasScaler.referenceResolution = new Vector2(1250, 1000);
                canvasScaler.matchWidthOrHeight = 1f;
            }
        }
    }
}
