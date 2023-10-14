using UnityEngine;

public class MouseInteractor : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask interactionMasks;
    [SerializeField] private Player player;

    private readonly float minimumSqrtDistanceToInteract = 1.2f;
    private int visitorLayerMask;
    
    private void Start()
    {
        visitorLayerMask = LayerMask.NameToLayer("Visitor");
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0)) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, interactionMasks))
        {
            if (hit.transform.gameObject.layer == visitorLayerMask)
            {
                float distance = (hit.transform.position - player.transform.position).sqrMagnitude;
                if (distance < minimumSqrtDistanceToInteract)
                {
                    if (hit.transform.TryGetComponent(out Visitor visitor))
                    {
                        if (visitor.Moving) return;
                        if (player.Beer == null)
                        {
                            player.GetOrder(visitor.GiveOrder());
                            return;
                        }

                        if (visitor.TryGetBeer(player.Beer))
                        {
                            
                        }
                    }
                }
            }
        }
    }
}
