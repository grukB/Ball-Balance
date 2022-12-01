using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSound : MonoBehaviour
{
    [SerializeField] AudioSource speaker;
    Rigidbody rb;
    [SerializeField] float soundVol;

    [SerializeField] float velocityToColide = 20;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        soundVol = collision.relativeVelocity.magnitude;
        if (gameObject.CompareTag("Sphere"))
        {
            speaker.pitch = Random.Range(2, 2.5f);
        }
        if (gameObject.CompareTag("BigSphere"))
        {
            speaker.pitch = Random.Range(1, 1.5f);
        }
        if (gameObject.CompareTag("MegaSphere"))
        {
            speaker.pitch = Random.Range(0.25f, 0.35f);
        }

        if (collision.relativeVelocity.magnitude > 30)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ground"))
            {
                speaker.volume = soundVol / 200;
                speaker.Play();
            }
        }
    }
}
