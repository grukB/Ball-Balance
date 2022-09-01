using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObjects : MonoBehaviour
{
    [SerializeField] float speed = 0.8f;
    [SerializeField] float amount = 0.001f;
    float shakeValue;

    void Update()
    {
        shakeValue = Mathf.Sin(Time.time * speed) * amount;
        transform.position += new Vector3(0, shakeValue, 0);
    }
}
