using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameObject target = null;
    private bool isHeld;

    void Update()
    {
        //touch
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.GetTouch(0).position, Vector2.zero);
            if (hit.transform.tag == "PartBody")
            {
                if (!isHeld) {
                    isHeld = true;
                    target = hit.transform.gameObject;
                }
            }
        }
        //move
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            if (target)
            {
                target.transform.position = Input.GetTouch(0).position;
            }
        }
        //release
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            if (target)
            {
                isHeld = false;
                target.GetComponent<PartBody>().GoHome();
                target = null;
            }
        }
    }
}
