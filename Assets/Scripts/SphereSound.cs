using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSound : MonoBehaviour
{
    [SerializeField] AudioSource speaker;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (gameObject.CompareTag("Sphere"))
        {
            speaker.pitch = Random.Range(4.45f, 4.55f);
        }
        if (gameObject.CompareTag("BigSphere"))
        {
            speaker.pitch = Random.Range(2.35f, 2.45f);
        }
        if (gameObject.CompareTag("MegaSphere"))
        {
            speaker.pitch = Random.Range(0.25f, 0.35f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.x > 5 | rb.velocity.y > 5 | rb.velocity.z > 5)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                speaker.Play();
            }

            if (collision.gameObject.CompareTag("Ground"))
            {
                speaker.Play();
            }
        }
    }
}
