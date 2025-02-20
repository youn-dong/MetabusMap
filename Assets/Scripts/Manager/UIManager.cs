using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager uiManager;
    public static UIManager Instance { get; set; }
    private NPC npc;
    [Header("MainScene에 사용")]
    public GameObject npcInfoPanel;
    public Text npcText;
    public GameObject namePanel;
    

    [Header("MiniGameScene에 사용")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public GameObject exitPanel;

    private List<string> currentDialogue;
    [SerializeField] private bool isCommunicated = false;
    private int dialogueIndex = 0;


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
            return;
        }
        npcInfoPanel = transform.GetChild(2).gameObject;
        scoreText = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        restartText = transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        if (npcText == null)
            npcText = FindObjectOfType<Text>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Start()
    {
        if (restartText != null)
            restartText.gameObject.SetActive(false);
        if (scoreText != null)
            scoreText.gameObject.SetActive(false);
        if (npc == null)
            npc = FindFirstObjectByType<NPC>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
            if (npcInfoPanel == null)
                npcInfoPanel = GameObject.Find("NPC Info");
            if (npcText == null)
                npcText = FindObjectOfType<Text>();
            if (scoreText == null)
                scoreText = FindObjectOfType<TextMeshProUGUI>();
            if (restartText == null)
                restartText = FindObjectOfType<TextMeshProUGUI>();

        if (scene.name == "MiniGameScene")
        {
            if (npcInfoPanel != null)  npcInfoPanel.SetActive(false);
            if (npcText != null)  npcText.gameObject.SetActive(false);
            if (scoreText != null) scoreText.gameObject.SetActive(true);
            if (namePanel != null) namePanel.gameObject.SetActive(false);

        }
        else if (scene.name == "MainScene")
        {
                if (npcInfoPanel != null) npcInfoPanel.SetActive(true);
                if (npcText != null) npcText.gameObject.SetActive(true);
                if (namePanel != null) namePanel.gameObject.SetActive(true);
                if (exitPanel != null) exitPanel.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        if(isCommunicated  && Input.GetKeyDown(KeyCode.Space))
            ShowNextDialogue();
    }
    public void SetReStart()
    {
        restartText.gameObject.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void StartDialogue(GameObject npcObject)
    {
        Debug.Log(isCommunicated);
        if (isCommunicated) return; //이미 대화하고있을때는 생략

        npc = npcObject.GetComponent<NPC>();

        if (npc == null) return;
        
        // RestartDialogue();

        currentDialogue = npc.GetNPCDialogue(npcObject);
        dialogueIndex = 0;
        npcInfoPanel.SetActive(true);
        isCommunicated = true;
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        if(dialogueIndex <currentDialogue.Count)
        {
            npcText.text = currentDialogue[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            HideDialogue();
        }
    }

    public void HideDialogue()
    {
        npcInfoPanel.SetActive(false);
        isCommunicated = false;
    }
    public void RestartDialogue()
    {
        dialogueIndex = 0;
        isCommunicated = false;
        npcInfoPanel.SetActive(false);
        npcText.text = "";
    }
}
