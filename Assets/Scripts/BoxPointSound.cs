using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPointSound : MonoBehaviour
{
    [SerializeField] AudioSource speaker;

    private void OnTriggerEnter(Collider other)
    {
        speaker.volume = .5f;

        if (other.gameObject.CompareTag("Sphere"))
        {
            speaker.pitch = Random.Range(1.25f, 1.75f);
            speaker.Play();
        }
        if (other.gameObject.CompareTag("BigSphere"))
        {
            speaker.pitch = Random.Range(0.75f, 1.25f);
            speaker.Play();
        }
        if (other.gameObject.CompareTag("MegaSphere"))
        {
            speaker.pitch = Random.Range(0.25f, 0.75f);
            speaker.Play();
        }
    }
}
