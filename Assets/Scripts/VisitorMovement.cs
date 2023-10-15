using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisitorMovement : MonoBehaviour
{
    [SerializeField] private Transform navMeshAgentTransform;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private List<Transform> movementPoints;
    [SerializeField] private float minimumDistanceToChangeTargetPoint = 0.01f;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform exitPoint;

    public bool Moving => navMeshAgent.hasPath;
    public event Action Stopped; 
    private int currentTargetIndex = -1;
    private static readonly int MoveValue = Animator.StringToHash("MoveValue");

    public void GoExit()
    {
        ChangeAnimation(AnimationType.Walking);
        navMeshAgent.SetDestination(exitPoint.position);
    }
    
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
            ChangeAnimation(AnimationType.Walking);
            if (currentTargetIndex == movementPoints.Count - 1)
            {
                StartCoroutine(ResetPath());
            }
        }
    }

    private IEnumerator ResetPath()
    {
        yield return new WaitUntil(() => navMeshAgent.remainingDistance == 0);
        ChangeAnimation(AnimationType.Idle);
        navMeshAgent.ResetPath();
        Stopped?.Invoke();
    }

    private void ChangeAnimation(AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.Idle:
                animator.SetFloat(MoveValue, 0);
                break;
            case AnimationType.Walking:
                animator.SetFloat(MoveValue, 1);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(animationType), animationType, null);
        }
    }
}

public enum AnimationType
{
    Idle,
    Walking
}
