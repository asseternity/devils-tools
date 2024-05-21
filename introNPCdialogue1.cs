using UnityEngine;
using UnityEngine.UIElements;

public class introNPCdialogue1 : MonoBehaviour
{
    public GameObject NPC;
    bool introPlayed = false;
    void Start() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.style.display = DisplayStyle.None;
    }
    void Update() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        introNPC NPCscript = NPC.GetComponent<introNPC>();
        if (NPCscript.timeToTalk == true && introPlayed == false) {
            introPlayed = true;
            VisualElement portrait = root.Q<VisualElement>("Portrait");
            Label npcName = root.Q<Label>("NPCname");
            Label npcDialogue = root.Q<Label>("NPCtext");
            npcName.text = "???";
            npcDialogue.text = "'Hi there. I hope you haven't been waiting here long.";
            Button option1 = root.Q<Button>("Option1");
            option1.text = "Ummm... what just happened?";
            option1.clicked += Option1;
            Button option2 = root.Q<Button>("Option2");
            option2.text = "Uh, hi? Who are you?";
            Button option3 = root.Q<Button>("Option3");
            option3.text = "Holy shit! What the fuck are you?";
            Button option4 = root.Q<Button>("Option4");
            option4.text = "...";
            root.style.display = DisplayStyle.Flex;
        }
    }
    void Option1() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;        
        Label npcName = root.Q<Label>("NPCname");
        Label npcDialogue = root.Q<Label>("NPCtext");
        npcName.text = "???";
        npcDialogue.text = "'Oh, was I too quick for you?";
        Button option1 = root.Q<Button>("Option1");
        option1.text = "O1";
        Button option2 = root.Q<Button>("Option2");
        option2.text = "O2";
        Button option3 = root.Q<Button>("Option3");
        option3.text = "O3";
        Button option4 = root.Q<Button>("Option4");
        option4.text = "O4";

    }
}
