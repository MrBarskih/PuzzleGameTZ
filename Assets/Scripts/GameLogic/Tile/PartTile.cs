using UnityEngine;

public class PartTile : BaseTile
{
    new private void Awake()
    {
        base.Awake();
    }

    new private void Start() 
    {
        base.Start();
        imageCompanent.color = new Color32(255, 142, 0, 255);//orange
        GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
    }
}
