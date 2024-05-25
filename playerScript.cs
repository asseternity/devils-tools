using UnityEngine;
using UnityEngine.AI;

public class playerScript : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent = null;
    public Camera orbitCamera;
    public GameObject crosshairs;
    public bool movementBlocked = true;
    private void Update()
    {
        if (movementBlocked == false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = orbitCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit; 
                if (Physics.Raycast(ray, out hit))
                {
                    _agent.SetDestination(hit.point);
                    GameObject crosshairsInstance = Instantiate(crosshairs, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                    Destroy(crosshairsInstance, 0.3f);
                }
            }
        }
    }
}
