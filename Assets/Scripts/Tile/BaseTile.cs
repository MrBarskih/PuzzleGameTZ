using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseTile : MonoBehaviour
{
    protected BoxCollider2D boxCollider2DCompanent;
    protected Image imageCompanent;
    
   protected void Awake()
    {
        boxCollider2DCompanent = gameObject.AddComponent<BoxCollider2D>();
        imageCompanent = gameObject.GetComponent<Image>();
    }

    protected void Start()
    {
        boxCollider2DCompanent.size = new Vector2(50, 50);
        boxCollider2DCompanent.isTrigger = true;
    }
}
