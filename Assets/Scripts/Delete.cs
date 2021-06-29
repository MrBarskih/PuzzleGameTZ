using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Delete : MonoBehaviour
{
    private Touch screenTouch;
    private void Start()
    {
    }

    private void Update()
    {
        GameObject target = null;
        if (Input.touchCount>0 && (Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.GetTouch(0).position, Vector2.zero);
            if (hit)
            {
                target = hit.transform.gameObject;
            }
            target.transform.position = Input.GetTouch(0).position;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("12");
        GameObject.Destroy(gameObject);
    }
}
