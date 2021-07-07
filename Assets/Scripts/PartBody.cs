using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(RectTransform))]
public class PartBody : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        ReturnToStartPosition();
    }

    public void ReturnToStartPosition() 
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
    }
}
