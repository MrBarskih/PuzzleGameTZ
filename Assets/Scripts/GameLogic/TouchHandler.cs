using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    [SerializeField] private RectTransform puzzleAreaTransform;

    private Transform grabbedPuzzlePart = null;
    private RaycastHit2D[] hittedByRayCast;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //Try to find objects under a touch
                hittedByRayCast = Physics2D.RaycastAll(Input.GetTouch(0).position, Vector2.zero);
                if (hittedByRayCast == null) return;

                //Find and mark object for dragging
                foreach (var gameObject in hittedByRayCast)
                {
                    if (gameObject.transform.gameObject.layer == 3)//PartTile
                    {
                        grabbedPuzzlePart = gameObject.transform.parent;
                        if (grabbedPuzzlePart.transform.parent != puzzleAreaTransform)
                        {
                            grabbedPuzzlePart.localScale = puzzleAreaTransform.localScale;
                        }
                        return;
                    }
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (grabbedPuzzlePart)
                {
                    grabbedPuzzlePart.position = Input.GetTouch(0).position;
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (grabbedPuzzlePart)
                {
                    grabbedPuzzlePart.GetComponent<PartBodyMagnet>().TryToMagnetize();
                    grabbedPuzzlePart = null;
                }
            }
        } 
    }
}
