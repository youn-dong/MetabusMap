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
        if (npcName != null)  //NPC�� �̸��� �ؽ�Ʈȭ�ؼ� �����
        {
            npcNameText.text = npcName;
        }


    }
    public void Update()
    {
        Vector3 worldPos = transform.position; // NPC�� ���� ��ǥ
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos); // ȭ�� ��ǥ�� ��ȯ


        Vector3 offset = new Vector3(0, 50, 0);
        // ȭ�� ��ǥ�� ��ȯ�� ���� UI �ؽ�Ʈ ��ġ�� ����
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
                return "�ȳ��ϽŰ�, ����ð� ���� �Ծ���?";
            case "Male NPC2":
                return "���� ���� ���� �غ��ڳ�?!";
            case "Female NPC":
                return "����� �� ���� �� �̰����!"; ;
            case "Female NPC2":
                return "ȣȣ ���� ���� ���� �����ɿ�?";
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
