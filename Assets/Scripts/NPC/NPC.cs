using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private UIManager uiManager;
    private string npcName;
    [SerializeField] private Text npcNameText;
    [SerializeField] private GameObject npcNameUIPrefab;
    private GameObject npcNameUIInstance;
    private NPCnaming npcNameUIScript; 
    //public Text npcText;
    public GameObject panel;
    public bool isPlayerNearby;

    public void Start()
    {
        if (uiManager == null)
            uiManager = FindFirstObjectByType<UIManager>();
        panel.SetActive(false);

        if(npcNameUIPrefab != null)
        {
            GameObject canvas = GameObject.Find("Canvas");
            npcNameUIInstance = Instantiate(npcNameUIPrefab, canvas.transform);
            npcNameUIScript = npcNameUIInstance.GetComponent<NPCnaming>();
            npcNameUIScript.targetNPC = this.transform;
            npcNameUIInstance.GetComponent<Text>().text = npcName;
        }


    }
    public void Update()
    {
        Vector3 worldPos = transform.position; // NPC의 월드 좌표
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos); // 화면 좌표로 변환


        // 화면 좌표로 변환된 값을 UI 텍스트 위치로 설정
        npcNameText.transform.position = screenPos;

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            uiManager.StartDialogue(gameObject);
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
                { "나와 게임 한판 해보겠나?!", "내 실력은 꽤나 수준급인데 괜찮겠나", "자 준비됐나?" } ;
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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
