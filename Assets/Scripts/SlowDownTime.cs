using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTime : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] float timeScaleInGame = 1.5f;
    [SerializeField] float timeScaleWhenGameOver = 0.05f;
    [SerializeField] float smoothTransitionToSlowDown = 1;
    float fixedDeltaTime;
    float smoothTimeValue;

    void Start()
    {
        Time.timeScale = timeScaleInGame;
        this.fixedDeltaTime = 0.008f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (gameManager.gameIsOver)
        {
            smoothTimeValue += smoothTransitionToSlowDown * Time.deltaTime;
            Time.timeScale = Mathf.Lerp(timeScaleInGame, timeScaleWhenGameOver, smoothTimeValue);
        }

        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            gameManager.gameIsOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            gameManager.gameIsOver = false;
        }
    }
}
