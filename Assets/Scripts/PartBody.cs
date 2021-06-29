using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBody : MonoBehaviour
{
    public bool isHeld;
    private Vector3 startPosition;

    private BoxCollider2D partBodyBoxColider2D;
    private RectTransform partBodyRectTransform;
    private Rigidbody2D partBodyRigidBody2D;
    void Awake()
    {
        partBodyBoxColider2D = gameObject.AddComponent<BoxCollider2D>();
        partBodyRectTransform = gameObject.AddComponent<RectTransform>();
        partBodyRigidBody2D = gameObject.AddComponent<Rigidbody2D>();

        partBodyRigidBody2D.bodyType = RigidbodyType2D.Kinematic;

        partBodyBoxColider2D.isTrigger = true;
        partBodyRectTransform.anchoredPosition = new Vector2(0, 0);

        gameObject.tag = "PartBody";
    }

    private void Start()
    {
        startPosition = gameObject.transform.position;
    }

    public void GoHome() 
    {
        partBodyRectTransform.position = startPosition;
    }
}
