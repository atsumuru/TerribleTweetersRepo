using System;
using System.Collections;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] AudioClip[] _clips;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.magnitude > 5f)
        {
            int index = UnityEngine.Random.Range(0, _clips.Length);
            AudioClip clip = _clips[index];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Collision was not strong enough to play sound." + collision.relativeVelocity.magnitude);
        }
    }
}
