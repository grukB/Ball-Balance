using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float speed = 75000f;
    float speedMax = 0.35f;

    Rigidbody playerRb;
    [SerializeField] GameObject gameManagerObject;
    GameManager gameManagerComp;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManagerComp = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManagerComp.gameIsOn)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            playerRb.AddTorque(Vector3.right * speed * horizontalInput);
            playerRb.maxAngularVelocity = speedMax;
        }
    }
}
