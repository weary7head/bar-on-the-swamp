using System;
using Unity.VisualScripting;
using UnityEngine;

public class Visitor : MonoBehaviour
{
    [SerializeField] private DialogueTrigger orderDialogueTrigger;
    [SerializeField] private DialogueTrigger rejectDialogueTrigger;
    [SerializeField] private DialogueTrigger approvalDialogueTrigger;
    [SerializeField] private VisitorMovement visitorMovement;
    [SerializeField] private Ingredient.BaseType targetBeerType;
    [SerializeField] private AttentionImage interactionSign;
    
    private DialogueType currentDialogueType = DialogueType.Order;
    public bool Moving => visitorMovement.Moving;

    private void Start()
    {
        visitorMovement.Stopped += ChangeAttention;
    }

    private void ChangeAttention()
    {
        interactionSign.EnableAttention();
        interactionSign.SetImage();
    }

    public bool TryGetBeer(Beer beer)
    {
        if (beer.raiting == Beer.Raiting.Погане || beer.Base.baseIngredient != targetBeerType)
        {
            rejectDialogueTrigger.TriggerDialogue();
            currentDialogueType = DialogueType.Order;
            return false;
        }

        currentDialogueType = DialogueType.Approval;
        approvalDialogueTrigger.TriggerDialogue();
        interactionSign.DisableAttention();
        return true;
    }

    public Ingredient.BaseType GiveOrder()
    {
        orderDialogueTrigger.TriggerDialogue();
        interactionSign.SetImage(AttentionImage.ImageType.Beer, targetBeerType);
        return targetBeerType;
    }

    public void OnDisable()
    {
        visitorMovement.Stopped -= ChangeAttention;
    }
}

public enum DialogueType
{
    Order,
    Reject,
    Approval
}