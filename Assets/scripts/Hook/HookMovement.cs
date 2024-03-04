using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    public Transform hookedtransform;
    private Camera mainCamera;
    private Collider2D coll;

    private bool canMove = true;

    void Awake()
    {
        mainCamera = Camera.main;
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (canMove && Input.GetMouseButton(0))
        {
            Vector3 vector = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 postion = transform.position;
            postion.x = vector.x;
            transform.position = postion;
        }

    }
}
