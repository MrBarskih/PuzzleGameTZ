using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartTile : BaseTile
{
    new void Awake()
    {
        base.Awake();
    }

    new void Start() 
    {
        base.Start();
        imageCompanent.color = new Color32(255, 142, 0, 255);
        gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
    }
}
