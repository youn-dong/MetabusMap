using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private NPC npc;
    public GameObject panel;
    public Text npcText;

    static UIManager uiManager;
    public static UIManager Instance { get; private set;  } 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (restartText != null)
        restartText.gameObject.SetActive(false);

        if( npc == null)
        {
            npc = FindFirstObjectByType<NPC>();
        }
    }

    public void SetReStart()
    {
        restartText.gameObject.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
   public void showDialogue(GameObject npcObject)
    {
        panel.SetActive(true);
        npcText.text = npc.GetNPCDialogue(npcObject);
        Invoke("HideDialogue", 3f);
    }
    public void HideDialogue()
    {
        panel.SetActive(false);
    }
    protected void CheckScene()
    {
        string CurrentScene = SceneManager.GetActiveScene().name;

        if(CurrentScene == "MainScene")
        {
            scoreText.text = null;
            restartText.text = null;
        }
    }


}
