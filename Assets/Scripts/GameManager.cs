using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerInput myPlayerInput;
    private InputAction restart;
    private InputAction quit;

    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public GameObject finishMenuUI;
    private AudioSource audioSource;

    public AudioClip lostLifeSound;


    public int lives;
    public int score;
    private int highScore; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        myPlayerInput.currentActionMap.Enable();
        restart = myPlayerInput.currentActionMap.FindAction("Restart");
        quit = myPlayerInput.currentActionMap.FindAction("Quit");

        restart.performed += Restart_performed;
        quit.performed += Quit_performed;

       
        lives = 3;
        score = 0;

      
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        
        UpdateLivesText();
        UpdateScoreText();
        UpdateHighScoreText();
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void Lives()
    {
        lives--;
        if (lostLifeSound != null)
        {
            audioSource.PlayOneShot(lostLifeSound);
        }

        UpdateLivesText();

        if (lives > 0)
        {
            Debug.Log("Player lost a life.");
        }
        else
        {
            Debug.Log("Game Over!");
            finishMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Score()
    {
        score += 100;
        UpdateScoreText();

       
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); 
            UpdateHighScoreText(); 
        }
    }

    private void Quit_performed(InputAction.CallbackContext context)
    {
        Application.Quit();
        Debug.Log("Quit Application");
    }

    private void Restart_performed(InputAction.CallbackContext obj)
    {
       
        SceneManager.LoadScene(0);
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
        finishMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }

}
