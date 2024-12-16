using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public GameObject StartMenu, SettingsMenu, ExitMenu;
    List<GameObject> PopUp = new List<GameObject>();
    public Button StartButton, SettingsButton, ExitButton;

    private void Start()
    {
        PopUp = new List<GameObject>().ToList();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("PopUp"))
        {
            // Add the game object to the list of PopUp
            PopUp.Add(go);
        }
        StartButton.onClick.AddListener(PopUp_StartGame);
        ExitButton.onClick.AddListener(PopUp_quit);
        SettingsButton.onClick.AddListener(PopUp_Settings);
    }

    // Update is called once per frame
    void Update()
    {   StartButton.onClick.AddListener(PopUp_StartGame);
        ExitButton.onClick.AddListener(PopUp_quit);
        SettingsButton.onClick.AddListener(PopUp_Settings);
    }


    // Popup is called
    public void PopUp_StartGame()
    {
        foreach (GameObject PopUp in PopUp.Where(go => go.tag == "Pop-Up"))
        {
            if (PopUp.name == "StartGame")
            {
                PopUp.SetActive(true);
            }
            else
            {
                PopUp.SetActive(false);
            }
        }
    }
    public void PopUp_quit()
    {
        foreach (GameObject PopUp in PopUp.Where(go => go.tag == "Pop-Up"))
        {
            if (PopUp.name == "ExitGame")
            {
                PopUp.SetActive(true);
            }
            else
            {
                PopUp.SetActive(false);
            }
        }
    }
    public void PopUp_Settings()
    {
        foreach (GameObject PopUp in PopUp.Where(go => go.tag == "Pop-Up"))
        {
            if (PopUp.name == "SettingsGame")
            {
                PopUp.SetActive(true);
            }
            else
            {
                PopUp.SetActive(false);
            }
        }
    }

    //Function
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        // Dapatkan nama scene yang sedang berjalan
        string currentSceneName = SceneManager.GetActiveScene().name;
        // Muat ulang scene yang sama
        SceneManager.LoadScene(currentSceneName);
    }
}