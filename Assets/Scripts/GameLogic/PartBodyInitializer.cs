using UnityEngine;
using UnityEngine.UI;

public class PartBodyInitializer : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<LayoutElement>().ignoreLayout = true;
    }

    public static void CreateComponent(GameObject where, Transform parent, float width, float height)
    {
        where.AddComponent<PartBodyInitializer>();

        where.AddComponent<PartBodyMagnet>().FirstParent = parent;
        where.transform.SetParent(parent, false);

        Vector2 puzzlePartBodySize = new Vector2(height, width);
        where.GetComponent<RectTransform>().sizeDelta = puzzlePartBodySize;
    }
}
