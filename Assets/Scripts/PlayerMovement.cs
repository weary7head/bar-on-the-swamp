using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    
    private static readonly int MoveValue = Animator.StringToHash("MoveValue");
    private Coroutine coroutine;

    private void Start()
    {
        ChangeAnimation(AnimationType.Idle);
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            ChangeAnimation(AnimationType.Walking);
            navMeshAgent.SetDestination(hit.point);
            coroutine = StartCoroutine(ResetPath());
        }
    }
    
    private IEnumerator ResetPath()
    {
        yield return new WaitUntil(() => navMeshAgent.remainingDistance == 0);
        ChangeAnimation(AnimationType.Idle);
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