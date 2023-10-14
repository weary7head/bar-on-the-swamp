using UnityEngine;

public class Visitor : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogueTrigger;

    public void TriggerDialogue()
    {
        dialogueTrigger.TriggerDialogue();
    }
}
