using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(CanvasScaler))]
public class CanvasScaleManager : MonoBehaviour
{
    CanvasScaler canvasScalerCompanent;
    ScreenOrientation currentScreeOrientation = ScreenOrientation.Portrait;

    private void Awake()
    {
        canvasScalerCompanent = GetComponent<CanvasScaler>();
    }

    private void Update()
    {
        if (Screen.orientation != currentScreeOrientation)
        {
            currentScreeOrientation = Screen.orientation;
            if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
            {
                canvasScalerCompanent.referenceResolution = new Vector2(1250, 2048);
                canvasScalerCompanent.matchWidthOrHeight = 0f;
            }
            else
            {
                canvasScalerCompanent.referenceResolution = new Vector2(1250, 1000);
                canvasScalerCompanent.matchWidthOrHeight = 1f;
            }
        }
    }
}
