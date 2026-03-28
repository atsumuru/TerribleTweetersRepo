using UnityEngine;

public class Bird : MonoBehaviour
{
    float _launchForce = 500f;

    Vector2 _startPosition;
    Rigidbody2D rb;
    SpriteRenderer _sprite;

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
    }

    private void OnMouseUp()
    {
        var currentPosition = rb.position;
        var direction = _startPosition - currentPosition;
        direction.Normalize();

        rb.isKinematic = false;
        rb.AddForce(direction * _launchForce);

        _sprite.color = Color.white;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    void Update()
    {
        
    }
}
