
using UnityEngine;

public class carDrive : MonoBehaviour
{    
    Rigidbody body;
    Vector3 velocity = Vector3.zero;
    float maxSpeed = 50f;
    float acceleration = 30f;
    public bool areWeGoing = false;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (areWeGoing) {
            CarGo();
        }
    }
    void CarGo() {
        float input = 5f;
        float speedChange = acceleration * Time.deltaTime * input;
        Vector3 currentVelocity = body.velocity;
        float newSpeed = Mathf.MoveTowards(currentVelocity.z, maxSpeed * input, speedChange);
        body.velocity = new Vector3(currentVelocity.x, currentVelocity.y, newSpeed);
    }
}
