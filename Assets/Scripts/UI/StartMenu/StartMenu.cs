using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        startButton.onClick.AddListener(OnStartClick);
        exitButton?.onClick.AddListener(OnExitClick);
    }



    private void OnStartClick()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }
    private void OnExitClick()
    {
        Application.Quit();
    }
    
    
}
