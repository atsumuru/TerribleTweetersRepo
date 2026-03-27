using UnityEngine;

public class Bird : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void Update()
    {
        
    }
}
