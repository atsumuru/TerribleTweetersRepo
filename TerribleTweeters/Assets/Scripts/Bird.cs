using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 5;

    Vector2 _startPosition;
    Rigidbody2D rb;
    SpriteRenderer _sprite;

    public bool isDragging { get; private set; }
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _startPosition = rb.position;
        rb.isKinematic = true;
    }

    private void OnMouseDown()
    {
        _sprite.color = Color.red;
        isDragging = true;
    }

    private void OnMouseUp()
    {
        var currentPosition = rb.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        rb.isKinematic = false;
        rb.AddForce(direction * _launchForce);

        _sprite.color = Color.white;

        isDragging = false;

        GetComponent<AudioSource>().Play();
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mousePosition;
        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _maxDragDistance);
        }

        rb.position = desiredPosition;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        rb.position = _startPosition;
        rb.isKinematic = true;
        rb.linearVelocity = Vector2.zero;
    }
}
