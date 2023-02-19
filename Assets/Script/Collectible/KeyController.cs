using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystem;
    [SerializeField]
    private SpriteRenderer sprite;

    private bool once = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null && once)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();

            var em = particleSystem.emission;
            var dur = particleSystem.duration;

            em.enabled = true;
            particleSystem.Play();

            once = false;
            sprite.enabled = false;
            Invoke(nameof(DestroyObj), dur);
        }
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }
}
