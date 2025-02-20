using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCnaming : MonoBehaviour
{
    public Transform targetNPC;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if(targetNPC != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetNPC.position);
            rectTransform.position = screenPos + new Vector3(0, 50, 0); // NPC 위쪽에 표시되도록 오프셋 추가
        }
    }
}
