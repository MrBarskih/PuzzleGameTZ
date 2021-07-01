using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceBuilder : MonoBehaviour
{
    private ScreenOrientation currentScreenOrientation;
    void Update()
    {
        if (Screen.orientation != currentScreenOrientation)
        {
            currentScreenOrientation = Screen.orientation;

            if (Screen.orientation == ScreenOrientation.Landscape)
            {

            }
            else
            {

            }
        }
    }
}
