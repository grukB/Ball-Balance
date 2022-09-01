using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject smoothedDesiredRotationReference;
    [SerializeField] Vector3 smoothedDesiredPos;
    [SerializeField] Vector3 targetPosition;
    float closeToPlayer = 0.8f;
    float smoothValue;
    Vector3 middlePos = new Vector3(0, 10, 0);

    private void LateUpdate()
    {
        if (target != null)
        {
            // Set smooth rotation
            smoothedDesiredPos = Vector3.Lerp(target.transform.position, middlePos, closeToPlayer);
            smoothedDesiredRotationReference.transform.LookAt(smoothedDesiredPos);

            // Smoothly transition to smooth rotation;
            smoothValue += 0.2f * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, smoothedDesiredRotationReference.transform.rotation, smoothValue);
        }
    }
}
