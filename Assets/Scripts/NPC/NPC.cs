using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private UIManager uiManager;

    private string npcName;
    [SerializeField] private Text npcNameText;
    [SerializeField] private GameObject npcNameUI_Prefab;
    private GameObject npcNameUI_Instance;
    private NPCnaming npcNameUIScript; 

    public GameObject panel;
    public bool isPlayerNearby;

    [SerializeField] private GameObject interactionUI_Prefab;
    private GameObject interactionUI_Instance;

    private bool gameChoice = false;

    public void Start()
    {
        if (uiManager == null)
            uiManager = FindFirstObjectByType<UIManager>();
        panel.SetActive(false);

        if(npcNameUI_Prefab != null)
        {
            GameObject canvas = GameObject.Find("Canvas");
            npcNameUI_Instance = Instantiate(npcNameUI_Prefab, canvas.transform);
            npcNameUIScript = npcNameUI_Instance.GetComponent<NPCnaming>();
            npcNameUIScript.targetNPC = this.transform;
            npcNameUI_Instance.GetComponent<Text>().text = npcName;
        }
    }
    public void Update()
    {
        Vector3 worldPos = transform.position; // NPC의 월드 좌표
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos); // 화면 좌표로 변환

        if(npcNameText != null)
        {
            // 화면 좌표로 변환된 값을 UI 텍스트 위치로 설정
            npcNameText.transform.position = screenPos;
        }
        else
        {
            Debug.LogWarning("NPC이름이 없습니다.");
        }

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            uiManager.StartDialogue(gameObject);
        }
        if (interactionUI_Instance != null) 
        {
            Vector3 interaction_screenPos= Camera.main.WorldToScreenPoint(transform.position);
            interactionUI_Instance.transform.position = screenPos + new Vector3(0, 80, 0);

        if(!gameChoice)
            {
                if(Input.GetKeyDown(KeyCode.Y))
                {
                Debug.Log("Y키 눌림 - 씬 변경 시도");
                    uiManager.HideDialogue();
                    SceneManager.LoadScene(1);
                    gameChoice = true;
                }
            }
        else if(Input.GetKeyDown(KeyCode.N))
            {
                uiManager.HideDialogue();
                gameChoice = false;
            }
        }
    }
    
    public List<string> GetNPCDialogue(GameObject gameObject)
    {
        switch (gameObject.name)
        {
            case "Male NPC":
                return new List<string> 
                { "안녕하신가?, 어서오시게, 밥은 먹었나?", "좋은 하루 보내시게" };
            case "Male NPC2":
                return new  List<string> 
                { "나와 게임 한판 해보겠나?!", "내 실력은 꽤나 수준급인데 괜찮겠나", "자 준비됐나?", 
                    "준비가 되었다면 Y로 시작,\t 안 되었다면 N을 눌러 강해져서 돌아오게나" } ;
            case "Female NPC":
                return new List<string> 
                { "당신이 꼭 남편 좀 이겨줘요!", "그는 너무 자신만만해 하는 스타일이에요", "근데 너무 잘생기지 않았나요?" } ;
            case "Female NPC2":
                return new List<string>
                {"호호 오늘 정말 날이 좋은걸요?", "산책하기 딱 좋은 날씨네요."};
            default:
                return new List<string> { "" };
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
        if(interactionUI_Prefab != null && interactionUI_Instance == null)
        {
            GameObject canvas = GameObject.Find("Canvas");
            interactionUI_Instance = Instantiate(interactionUI_Prefab, canvas.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
        if(interactionUI_Instance != null)
        {
            Destroy(interactionUI_Instance);
            interactionUI_Instance = null;
        }
    }
}
