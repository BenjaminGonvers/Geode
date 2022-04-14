using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayOnCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;

    public AudioSource audioSource;
    public float maxForce = 5;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    } 


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

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Finish"))
        {
            Collect();
            // tryings for dissapearance of Player renderer
            spriteRenderer.enabled = false;
        }
    }

    private void Collect()
    {
        // play the collect graphics
        collectParticle.Play();
        // play the collect sound effects
    }
}

