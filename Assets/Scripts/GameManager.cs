using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float gravity = 22;
    public bool resetGame = false;
    public bool gameIsOn = false;
    public bool gameIsOver = false;
    public bool gameIsPause = false;

    public GameObject mainMenu;
    public GameObject mainCamera;
    public GameObject menuTitle;
    public GameObject scoreText;
    public GameObject vignette;
    public GameObject gameArea;
    public GameObject playerBox;
    public GameObject playerSkate;
    public GameObject pauseBackground;

    Animator vignetteAnimator;
    Animator scoreTextAnimator;
    Animator cameraAnimator;
    Animator titleAnimator;

    void Start()
    {
        Physics.gravity = Vector3.down * gravity;
        cameraAnimator = mainCamera.GetComponent<Animator>();
        titleAnimator = menuTitle.GetComponent<Animator>();
        scoreTextAnimator = scoreText.GetComponent<Animator>();
        vignetteAnimator = vignette.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsOn)
        {
            if (!gameIsPause)
            {
                pauseBackground.SetActive(true);
                gameIsPause = true;
                Time.timeScale = 0f;
            }
            else
            {
                pauseBackground.SetActive(false);
                gameIsPause = false;
                Time.timeScale = 1.5f;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && !gameIsOn)
        {
            StartCoroutine("GameIsArtive");
            cameraAnimator.SetBool("start game", true);
            titleAnimator.SetBool("start game", true);
            scoreTextAnimator.SetBool("start game", true);
        }

        if (gameIsOn)
        {
            mainMenu.SetActive(false);
            RestartGame();
        }

        if (gameIsOver)
        {
            vignetteAnimator.SetTrigger("game over");
        }
    }

    void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }

    IEnumerator GameIsArtive()
    {
        yield return new WaitForSeconds(2.5f);
        gameIsOn = true;
    }
}
