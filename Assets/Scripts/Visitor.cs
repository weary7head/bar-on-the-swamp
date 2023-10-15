using UnityEngine;

public class Visitor : MonoBehaviour
{
    [SerializeField] private DialogueTrigger orderDialogueTrigger;
    [SerializeField] private DialogueTrigger rejectDialogueTrigger;
    [SerializeField] private DialogueTrigger approvalDialogueTrigger;
    [SerializeField] private VisitorMovement visitorMovement;
    [SerializeField] private Ingredient.BaseType targetBeerType;
    
    private DialogueType currentDialogueType = DialogueType.Order;
    public bool Moving => visitorMovement.Moving;

    public bool TryGetBeer(Beer beer)
    {
        if (beer.raiting == Beer.Raiting.Погане || beer.Base.baseIngredient != targetBeerType)
        {
            rejectDialogueTrigger.TriggerDialogue(null);
            currentDialogueType = DialogueType.Order;
            return false;
        }

        currentDialogueType = DialogueType.Approval;
        approvalDialogueTrigger.TriggerDialogue(visitorMovement.GoExit);
        return true;
    }

    public Ingredient.BaseType GiveOrder()
    {
        orderDialogueTrigger.TriggerDialogue(null);
        return targetBeerType;
    }
}

public enum DialogueType
{
    Order,
    Reject,
    Approval
}