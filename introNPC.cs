using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class introNPC : MonoBehaviour
{
    // 1) floats up to the player
    // 2) dialogue window is open
    // 3) image is in the corner
    // 4) name next to it
    // 5) their dialogue shows up
    // 6) and two options under
    public GameObject player;
    public Camera orbitCamera;
    public Camera mainCamera;
    bool movementDone = false;
    bool leaveRotationDone = false;
    public bool timeToTalk = false;
    public bool timeToLeave = false;
    void Start() {
        orbitCamera.enabled = false;
        mainCamera.enabled = true;
    }
    void Update() {
        FloatUp();
        RotatePlayer();
        if (timeToLeave && !leaveRotationDone) {
            Leave();
        }
        if (leaveRotationDone) {
            Leave2();
        }
    }
    void FloatUp() {
        if (transform.localPosition.z <= 69) {
            Vector3 displacement = new Vector3(0f, 0f, 0.03f);
            transform.localPosition += displacement;
        } else {
            Invoke("MovementFlag", 0.5f);
        }
    }
    void MovementFlag() {
        movementDone = true;
    }
    void RotatePlayer() {
        if (movementDone) {
            if (player.transform.localRotation.eulerAngles.y >= 180f) {
                Vector3 currentEulerAngles = player.transform.localRotation.eulerAngles;
                currentEulerAngles.y -= 5f;
                player.transform.localRotation = Quaternion.Euler(currentEulerAngles);
            } else {
                Invoke("TalkFlag", 0.5f);
            }
        }
    }
    void TalkFlag() {
        timeToTalk = true;
    }
    void Leave() {
        if (transform.localRotation.eulerAngles.y != 180f) {
            Vector3 NPCcurrentEulerAngles = transform.localRotation.eulerAngles;
            NPCcurrentEulerAngles.y += 5f;
            transform.localRotation = Quaternion.Euler(NPCcurrentEulerAngles);
        } else {
            Invoke("LeaveFlag", 0.5f);
        }
    }
    void LeaveFlag() {
        leaveRotationDone = true;
    }
    void Leave2() {
        if (transform.localPosition.z >= 50) {
            Vector3 displacement = new Vector3(0f, 0f, -0.09f);
            transform.localPosition += displacement;
        } else {
            Destroy(gameObject, 0.5f);        
            mainCamera.enabled = false;
            orbitCamera.enabled = true;
            playerScript var_playerScript = player.GetComponent<playerScript>();
            var_playerScript.movementBlocked = false;
        }        
    }
}
