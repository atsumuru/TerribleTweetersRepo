using System;
using System.Collections;
using UnityEngine;

[SelectionBase] 

public class Monster : MonoBehaviour
{

    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _deathEffect;

    bool _hasDied;

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator Start()
    {
        while (_hasDied == false)
        {
            float delay = UnityEngine.Random.Range(5, 30);
            yield return new WaitForSeconds(delay);
            if (_hasDied == false)
            {
            GetComponent<AudioSource>().Play();
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die());
        }
    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        if (_hasDied)
            return false;

        bool isBird = collision.gameObject.CompareTag("Bird");
        bool isCrate = collision.gameObject.CompareTag("Crate");

        if (!isBird && !isCrate)
            return false;

        foreach (var contact in collision.contacts)
        {
            Vector2 normal = contact.normal;

            if (isBird && normal.y < -0.5f)
                return true;

            if (isCrate && normal.y < 0.5f)
                return true;
        }

        return false;
    }

    IEnumerator Die ()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _deathEffect.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

}
