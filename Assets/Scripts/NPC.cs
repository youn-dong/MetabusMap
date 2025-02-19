using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private UIManager uiManager;
    private string npcName;
    [SerializeField] private Text npcNameText;
    public Text npcText;
    public GameObject panel;
    public bool isPlayerNearby;

    public void Start()
    {
        if (uiManager == null)
            uiManager = FindFirstObjectByType<UIManager>();
        panel.SetActive(false);
        if (npcName != null)  //NPC의 이름을 텍스트화해서 만들기
        {
            npcNameText.text = npcName;
        }


    }
    public void Update()
    {
        Vector3 worldPos = transform.position; // NPC의 월드 좌표
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos); // 화면 좌표로 변환


        Vector3 offset = new Vector3(0, 50, 0);
        // 화면 좌표로 변환된 값을 UI 텍스트 위치로 설정
        npcNameText.transform.position = screenPos + offset;

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            uiManager.showDialogue(gameObject);
        }
    }
    
    public string GetNPCDialogue(GameObject gameObject)
    {
        switch (gameObject.name)
        {
            case "Male NPC":
                return "안녕하신가, 어서오시게 밥은 먹었나?";
            case "Male NPC2":
                return "나와 게임 한판 해보겠나?!";
            case "Female NPC":
                return "당신이 꼭 남편 좀 이겨줘요!"; ;
            case "Female NPC2":
                return "호호 오늘 정말 날이 좋은걸요?";
            default:
                return "";
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
