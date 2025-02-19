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
                return "안녕하신가, 어서오시게 밥은 먹었나?";
            case NPCtype.MaleNPC2:
                return "나와 게임 한판 해보겠나?!";
            case NPCtype.FemaleNPC:
                return "호호 오늘 정말 날이 좋은걸요?";
            case NPCtype.FemaleNPC2:
                return "당신이 꼭 남편 좀 이겨줘요!";
            default:
                return "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
