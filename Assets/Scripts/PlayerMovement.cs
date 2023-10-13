using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask groundLayer;
    
    private void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit)) navMeshAgent.SetDestination(hit.point);
    }
}