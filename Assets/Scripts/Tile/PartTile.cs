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
    }
}
