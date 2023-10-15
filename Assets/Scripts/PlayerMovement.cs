using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Animator animator;
    [SerializeField] private MouseInteractor mouseInteractor;
    
    private readonly int moveValue = Animator.StringToHash("MoveValue");
    private Coroutine coroutine;
    private int layer;

    private void Start()
    {
        layer = LayerMask.NameToLayer("Ground");
        ChangeAnimation(AnimationType.Idle);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0) || !mouseInteractor.IsInteractionOn) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform.gameObject.layer == layer)
            {
                if (coroutine != null) StopCoroutine(coroutine);
                ChangeAnimation(AnimationType.Walking);
                navMeshAgent.SetDestination(hit.point);
                coroutine = StartCoroutine(ResetPath());
            }
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
                animator.SetFloat(moveValue, 0);
                break;
            case AnimationType.Walking:
                animator.SetFloat(moveValue, 1);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(animationType), animationType, null);
        }
    }
}