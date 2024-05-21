using UnityEngine;
using UnityEngine.UIElements;

public class introNPCdialogue1 : MonoBehaviour
{
    public GameObject NPC;
    void Start() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.style.display = DisplayStyle.None;
    }
    void Update() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        introNPC NPCscript = NPC.GetComponent<introNPC>();
        if (NPCscript.timeToTalk == true) {
            root.style.display = DisplayStyle.Flex;
        }
    }
}
