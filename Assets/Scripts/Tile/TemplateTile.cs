using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemplateTile : MonoBehaviour
{
    private BoxCollider2D templateTileBoxCollider2D;
    private Rigidbody2D templateTileRigidBody2D;
    void Awake()
    {
        templateTileBoxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        templateTileRigidBody2D = gameObject.AddComponent<Rigidbody2D>();

        templateTileBoxCollider2D.size = new Vector2(50, 50);
        templateTileBoxCollider2D.isTrigger = true;


        templateTileRigidBody2D.bodyType = RigidbodyType2D.Kinematic;

        gameObject.GetComponent<Image>().color = new Color32(194, 255, 131, 255);
        gameObject.GetComponent<Image>().raycastTarget = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("V mene");
    }
}
