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
    private NPC npc;
    public GameObject panel;
    public Text npcText;

    static UIManager uiManager;
    public static UIManager Instance { get; set;  } 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    private List<string> currentDialogue;
    private bool isCommunicated = false;
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
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        restartText = FindObjectOfType<TextMeshProUGUI>();
    }
    private void Start()
    {
        if (restartText != null)
            restartText.gameObject.SetActive(false);

        if ( npc == null)
            npc = FindFirstObjectByType<NPC>();
         
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
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }
    public void StartDialogue(GameObject npcObject)
    {
        if (isCommunicated) return; //이미 대화하고있을때는 생략

        npc = npcObject.GetComponent<NPC>();

        if(npc==null) return;

        RestartDialogue();

        currentDialogue = npc.GetNPCDialogue(npcObject);
        dialogueIndex = 0;
        panel.SetActive(true);
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
        panel.SetActive(false);
        isCommunicated = false;
    }
    public void RestartDialogue()
    {
        dialogueIndex = 0;
        isCommunicated = false;
        panel.SetActive(false);
        npcText.text = "";
    }
}
