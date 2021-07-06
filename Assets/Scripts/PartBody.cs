using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBody : MonoBehaviour
{
    public bool isHeld;

    private BoxCollider2D partBodyBoxColider2D;
    private RectTransform partBodyRectTransform;
    void Awake()
    {
        partBodyBoxColider2D = gameObject.AddComponent<BoxCollider2D>();
        partBodyRectTransform = gameObject.AddComponent<RectTransform>();

        partBodyBoxColider2D.isTrigger = true;
        GoHome();

        gameObject.tag = "PartBody";
    }

    public void GoHome() 
    {
        partBodyRectTransform.anchoredPosition = new Vector2(0,0);
    }
}
