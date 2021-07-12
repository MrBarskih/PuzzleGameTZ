using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D), typeof(RectTransform), typeof(Image))]
public class BaseTile : MonoBehaviour
{
    protected BoxCollider2D boxCollider2DCompanent;
    protected Image imageCompanent;
    
    
   protected void Awake()
    {
        boxCollider2DCompanent = GetComponent<BoxCollider2D>();
        imageCompanent = GetComponent<Image>();

        boxCollider2DCompanent.isTrigger = true;
    }
}
