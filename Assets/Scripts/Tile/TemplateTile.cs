using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemplateTile : BaseTile
{

    new void Awake()
    {
        base.Awake();  
    }

    new void Start()
    {
        base.Start();
        imageCompanent.color = new Color32(194, 255, 131, 255);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("V mene");
    }
}
