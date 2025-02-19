using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }
    private UIManager uimanager;
    public  UIManager UImanager { get { return uimanager; } }
    private int currentScore = 0;

    private void Awake()
    {
        gameManager = this;
        uimanager = FindObjectOfType<UIManager>();
    }
    private void Start()
    {
        uimanager.UpdateScore(0);
    }
    public void GameOver()
    {
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
}