using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeUntilGameIsOn : MonoBehaviour
{
    Rigidbody rg;
    [SerializeField] GameObject gameManagerObject;
    GameManager gm;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        gm = gameManagerObject.GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        rg.constraints = RigidbodyConstraints.FreezePositionX;

        if (!gm.gameIsOn)
        {
            rg.constraints = RigidbodyConstraints.FreezePosition;
        }

        if (gm.gameIsOn && gameObject.CompareTag("Box"))
        {
            rg.constraints = RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezeRotationZ;
        }

        if (gm.gameIsOn && gameObject.CompareTag("Skate"))
        {
            rg.constraints = RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
