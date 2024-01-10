using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseDown();
        }

        if (Input.GetMouseButton(0))
        {
            HandleMouseDrag();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                HandleMouseDown();
            }

            if (touch.phase == TouchPhase.Moved)
            {
                HandleMouseDrag();
            }
        }
    }

    void HandleMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint;

        if (Input.touchCount > 0)
        {
            mousePoint = Input.GetTouch(0).position;
        }
        else
        {
            mousePoint = Input.mousePosition;
        }

        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void HandleMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }
}
