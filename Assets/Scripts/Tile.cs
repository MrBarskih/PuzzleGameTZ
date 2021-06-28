using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private bool isPartOfTemplate = false;
    public bool IsPartOfTemplate 
    {
        get { return isPartOfTemplate; }

        set 
        {
            if (value)
            {
                isPartOfTemplate = value;
                imageComponent.color = new Color32(194, 255, 131, 255);
            }
        } 
    }

    [SerializeField]
    private Image imageComponent;

    // Update is called once per frame
    void Update()
    {
        
    }
}
