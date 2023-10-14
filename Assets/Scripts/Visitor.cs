using UnityEngine;

public class Visitor : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private VisitorMovement visitorMovement;

    public bool Moving => visitorMovement.Moving;

    public void TriggerDialogue()
    {
        dialogueTrigger.TriggerDialogue();
    }
}
