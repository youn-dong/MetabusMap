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
        Vector3 worldPos = transform.position; // NPC�� ���� ��ǥ
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos); // ȭ�� ��ǥ�� ��ȯ


        // ȭ�� ��ǥ�� ��ȯ�� ���� UI �ؽ�Ʈ ��ġ�� ����
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
                { "�ȳ��ϽŰ�?, ����ð�, ���� �Ծ���?", "���� �Ϸ� �����ð�" };
            case "Male NPC2":
                return new  List<string> 
                { "���� ���� ���� �غ��ڳ�?!", "�� �Ƿ��� �ϳ� ���ر��ε� �����ڳ�", "�� �غ�Ƴ�?" } ;
            case "Female NPC":
                return new List<string> 
                { "����� �� ���� �� �̰����!", "�״� �ʹ� �ڽŸ����� �ϴ� ��Ÿ���̿���", "�ٵ� �ʹ� �߻����� �ʾҳ���?" } ;
            case "Female NPC2":
                return new List<string>
                {"ȣȣ ���� ���� ���� �����ɿ�?", "��å�ϱ� �� ���� �����׿�."};
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
