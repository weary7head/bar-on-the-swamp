using UnityEngine;

public class DialogueTrigger : MonoBehaviour 
{
	[SerializeField] private Dialogue dialogue;
	[SerializeField] private DialogueManager dialogueManager;

	public void TriggerDialogue ()
	{
		dialogueManager.StartDialogue(dialogue);
	}
}