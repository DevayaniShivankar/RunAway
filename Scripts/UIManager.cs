using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public FirebaseManager fbm;
    public bool IsLoggedIn;

    //Screen object variables
    public GameObject loginUI;
    public GameObject registerUI;
    public GameObject mainMenuUI;
    public GameObject GameUI;
    public GameObject DieUI;

    public GameObject LogInButton;
    public GameObject LogOutButton;
    [SerializeField] GameObject groundSpawner;

    private void Update()
    {
        IsLoggedIn = fbm.IsLoggedIn;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    //Functions to change the login screen UI
    public void ClearScreen()
    {
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        mainMenuUI.SetActive(false);
        GameUI.SetActive(false);
        DieUI.SetActive(false);
    }

    public void LoginScreen() //Back button
    {
        ClearScreen();
        loginUI.SetActive(true);
    }
    public void RegisterScreen() // Register button
    {
        ClearScreen();
        registerUI.SetActive(true);
    }

    public void MainMenuScreen() //Main Menu Button
    {
        ClearScreen();
        mainMenuUI.SetActive(true);

        if (IsLoggedIn == true)
        {
            LogInButton.SetActive(false);
            LogOutButton.SetActive(true);
        }
        else
        {
            LogInButton.SetActive(true);
            LogOutButton.SetActive(false);
        }
        
    }

    public void GameScreen() //Play Button
    {
        groundSpawner.GetComponent<GroundSpawner>().enabled = true;
        ClearScreen();
        GameUI.SetActive(true);

    }

    public void DieScreen() //On Death
    {
        ClearScreen();
        DieUI.SetActive(true);
    }
}