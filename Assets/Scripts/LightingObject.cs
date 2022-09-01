using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingObject : MonoBehaviour
{
    Rigidbody rb;
    float newMass = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            StartCoroutine(WaitToLightObject());
        }
    }

    IEnumerator WaitToLightObject()
    {
        yield return new WaitForSeconds(0.15f);
        rb.mass = newMass;
    }
}
