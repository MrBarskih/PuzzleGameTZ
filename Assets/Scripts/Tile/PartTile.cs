using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartTile : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<Image>().color = new Color32(255, 142, 0, 255);
        gameObject.GetComponent<Image>().raycastTarget = false;
    }
}
