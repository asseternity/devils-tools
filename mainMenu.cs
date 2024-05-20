using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class mainMenu : MonoBehaviour
{
    public GameObject car;
    void Update() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement newGame = root.Q<Button>("NewGame");
        newGame.RegisterCallback<ClickEvent>((evt) => NewGame());        
    }
    void NewGame() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.style.display = DisplayStyle.None;
        carDrive carScript = car.GetComponent<carDrive>();
        carScript.areWeGoing = true;
        Invoke("LoadSceneStart", 5f);
    }
    void LoadSceneStart() {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
