using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public TextMeshProUGUI npcText;
    public enum NPCtype
    {
        MaleNPC,
        MaleNPC2,
        FemaleNPC,
        FemaleNPC2,
    }
    public void SendNPCText(NPCtype npcType)
    {
        string npcDialogue = GetNPCDialogue(npcType);
        npcText.text = npcDialogue;
    }
    public string GetNPCDialogue(NPCtype npcType)
    {
        switch (npcType)
        {
            case NPCtype.MaleNPC:
                return "�ȳ��ϽŰ�, ����ð� ���� �Ծ���?";
            case NPCtype.MaleNPC2:
                return "���� ���� ���� �غ��ڳ�?!";
            case NPCtype.FemaleNPC:
                return "ȣȣ ���� ���� ���� �����ɿ�?";
            case NPCtype.FemaleNPC2:
                return "����� �� ���� �� �̰����!";
            default:
                return "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
