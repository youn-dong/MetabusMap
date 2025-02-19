using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager uiManager;
    public static UIManager Instance { get { return uiManager; } }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    private void Awake()
    {
        if(Instance == null)
        {
            uiManager = this;
        }
    }
    private void Start()
    {
        if (restartText != null)
        restartText.gameObject.SetActive(false);
    }

    public void SetReStart()
    {
        restartText.gameObject.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
