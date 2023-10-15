using UnityEngine;

public class MouseInteractor : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Player player;
    [SerializeField] private GameObject beerCraftingGameObject;
    [SerializeField] private BeerCrafting beerCrafting;
    [SerializeField] private float minimumSqrtDistanceToInteract = 62f;

    public bool IsInteractionOn { get; set; } = true;
    
   
    private int visitorLayerMask;
    private int potLayerMask;
    
    private void Start()
    {
        visitorLayerMask = LayerMask.NameToLayer("Visitor");
        potLayerMask = LayerMask.NameToLayer("Pot");
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0) || !IsInteractionOn) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            float distance = (hit.transform.position - player.transform.position).sqrMagnitude;
            Debug.Log($"{distance} {minimumSqrtDistanceToInteract} {distance < minimumSqrtDistanceToInteract}");
            if (distance <= minimumSqrtDistanceToInteract)
            {
                if (hit.transform.gameObject.layer == visitorLayerMask)
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
                
                if (hit.transform.gameObject.layer == potLayerMask && player.CurrentOrderBeerType == Ingredient.BaseType.None)
                {
                    beerCraftingGameObject.SetActive(true);
                    IsInteractionOn = false;
                }
            }
        }
    }
}
