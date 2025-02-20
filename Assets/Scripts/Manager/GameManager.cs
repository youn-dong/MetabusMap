using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; } 
    private  UIManager uimanager;
    private int currentScore = 0;
    private GameObject exitPanel;
    private bool isGameOver = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        uimanager = FindObjectOfType<UIManager>();
    
    }
    private void Start()
    { 
        uimanager.UpdateScore(0);
    }
    public void GameOver()
    {
        isGameOver = true;
        uimanager.restartText.gameObject.SetActive(true);
        uimanager.exitPanel.gameObject.SetActive(true);
        uimanager.SetReStart();
       
    }
    public void RestartGame()
    {
        uimanager.restartText.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int score)
    {
        currentScore += score;
        uimanager.UpdateScore(currentScore); 
    }
    private void Update()
    {
        if(isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            uimanager.restartText.gameObject.SetActive(false);
            uimanager.exitPanel.gameObject.SetActive(false);
        }
        
    }
}