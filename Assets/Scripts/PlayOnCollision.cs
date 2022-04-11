using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PlayOnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
        {
            Debug.Log("caca");
            audioSource.Play();
        }
    }
}*/

public class PlayOnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public float maxForce = 5;
    void OnCollisionEnter2D(Collision2D collision)
    {
        float force = collision.relativeVelocity.magnitude;
        float volume = 1;
        if (force <= maxForce)
        {
            volume = force / maxForce;
        }
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
}