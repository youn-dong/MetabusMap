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
        Vector3 worldPos = transform.position; // NPC�� ���� ��ǥ
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos); // ȭ�� ��ǥ�� ��ȯ

        if(npcNameText != null)
        {
            // ȭ�� ��ǥ�� ��ȯ�� ���� UI �ؽ�Ʈ ��ġ�� ����
            npcNameText.transform.position = screenPos;
        }
        else
        {
            Debug.LogWarning("NPC�̸��� �����ϴ�.");
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
                Debug.Log("YŰ ���� - �� ���� �õ�");
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
                { "�ȳ��ϽŰ�?, ����ð�, ���� �Ծ���?", "���� �Ϸ� �����ð�" };
            case "Male NPC2":
                return new  List<string> 
                { "���� ���� ���� �غ��ڳ�?!", "�� �Ƿ��� �ϳ� ���ر��ε� �����ڳ�", "�� �غ�Ƴ�?", 
                    "�غ� �Ǿ��ٸ� Y�� ����,\t �� �Ǿ��ٸ� N�� ���� �������� ���ƿ��Գ�" } ;
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
