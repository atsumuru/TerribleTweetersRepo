using System;
using System.Collections;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    LineRenderer _lineRenderer;
    Bird _bird;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _bird = FindObjectOfType<Bird>();

        // Vector3 lineZeroPosition = new Vector3(
        //     _bird.transform.position.x,
        //     _bird.transform.position.y,
        //     -0.1f);

        _lineRenderer.SetPosition(0, _bird.transform.position);
    }

    void Update()
    {
        if (_bird.isDragging)
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(1, _bird.transform.position);
        }
        else
        {
            _lineRenderer.enabled = false;
        }
    }
}
