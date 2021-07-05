using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBody : MonoBehaviour
{
    public bool isHeld;

    private BoxCollider2D partBodyBoxColider2D;
    private RectTransform partBodyRectTransform;
    private ScreenOrientation currentScreenOrientation = ScreenOrientation.AutoRotation;
    void Awake()
    {
        partBodyBoxColider2D = gameObject.AddComponent<BoxCollider2D>();
        partBodyRectTransform = gameObject.AddComponent<RectTransform>();

        partBodyBoxColider2D.isTrigger = true;
        GoHome();

        gameObject.tag = "PartBody";

        
    }

    private void Update()
    {
        if (Screen.orientation != currentScreenOrientation)
        {
            currentScreenOrientation = Screen.orientation;
            FitParent();
        }
    }

    public void GoHome() 
    {
        partBodyRectTransform.anchoredPosition = new Vector2(0,0);
    }

    private void FitParent()
    {
        var containerSizeX = (gameObject.transform.parent.GetComponent<RectTransform>().anchorMax.x - gameObject.transform.parent.GetComponent<RectTransform>().anchorMin.x) * Screen.safeArea.width;
        var containerSizeY = 350f;

        var bodyPuzzlePartSizeX = gameObject.GetComponent<RectTransform>().rect.width * GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localScale.x;
        var bodyPuzzlePartSizeY = gameObject.GetComponent<RectTransform>().rect.height * GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localScale.y;

        var containerBodyRatioX = containerSizeX / bodyPuzzlePartSizeX;
        var containerBodyRatioY = containerSizeY / bodyPuzzlePartSizeY;

        if (containerBodyRatioX > containerBodyRatioY)
        {
            gameObject.transform.localScale = new Vector3(containerBodyRatioY, containerBodyRatioY);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(containerBodyRatioX, containerBodyRatioX);
        }
    }
}
