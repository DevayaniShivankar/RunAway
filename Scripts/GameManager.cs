using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject groundSpawner;
    [SerializeField] FirebaseManager firebaseManager;

    public void IncrementScore()
    {
        score = score + 5; 
        scoreText.text = "SCORE: " + score;
        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        inst = this;
        
    }

    private void Start()
    {
        UIManager.instance.MainMenuScreen();
    }


    public void Restart()
    {
        score = 0;
        UIManager.instance.GameScreen();
        playerMovement.alive = true;
        playerMovement.ResetPosi();
        groundSpawner.GetComponent<GroundSpawner>().enabled = true;
        //groundSpawner.SetActive(true);
        //groundSpawner.ResetTilePosi();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
