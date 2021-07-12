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
                hittedByRayCast = Physics2D.RaycastAll(Input.GetTouch(0).position, Vector2.zero);
                if (hittedByRayCast == null) return;
                foreach (var gameObject in hittedByRayCast)
                {
                    if (gameObject.transform.gameObject.layer == 3)//PartTile
                    {
                        grabbedPuzzlePart = gameObject.transform.parent;
                        grabbedPuzzlePart.localScale = puzzleAreaTransform.localScale;
                        grabbedPuzzlePart.GetComponent<PartBody>().SwitchStatOfChildTilesRigidBodies();
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
                    //grabbedPuzzlePart.localScale = new Vector3(1f, 1f);
                    //grabbedPuzzlePart.GetComponent<PartBody>().ReturnToStartPosition();
                    grabbedPuzzlePart.GetComponent<PartBody>().SwitchStatOfChildTilesRigidBodies();
                    grabbedPuzzlePart = null;
                }
            }
        } 
    }
}
