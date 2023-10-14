using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisitorMovement : MonoBehaviour
{
    [SerializeField] private Transform navMeshAgentTransform;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private List<Transform> movementPoints;
    [SerializeField] private float minimumDistanceToChangeTargetPoint = 0.01f;

    private int currentTargetIndex = -1;

    private void Start()
    {
       SetNextDestination();
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance <= minimumDistanceToChangeTargetPoint)
        {
            SetNextDestination();
        }
    }

    private void SetNextDestination()
    {
        currentTargetIndex++;
        if (currentTargetIndex < movementPoints.Count)
        {
            Vector3 targetPosition = new Vector3(movementPoints[currentTargetIndex].position.x,
                navMeshAgentTransform.position.y, movementPoints[currentTargetIndex].position.z);
            navMeshAgent.SetDestination(targetPosition);
        }
    }
}
