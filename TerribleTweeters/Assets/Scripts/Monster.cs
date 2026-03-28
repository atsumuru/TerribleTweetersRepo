using UnityEngine;

public class Monster : MonoBehaviour
{

    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _deathEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            Die();
        }
    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird == null)
            return true;

        if (collision.contacts[0].normal.y < -0.5)
            return true;

        return false;
    }
    void Die ()
    {
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _deathEffect.Play();
        //gameObject.SetActive(false);
    }

}
