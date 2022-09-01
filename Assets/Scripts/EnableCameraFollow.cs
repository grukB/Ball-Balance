using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCameraFollow : MonoBehaviour
{
    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.GetComponent<GameManager>();
        cameraFollow.enabled = !cameraFollow.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameIsOn)
        {
            cameraFollow.enabled = true;
        }
    }
}
