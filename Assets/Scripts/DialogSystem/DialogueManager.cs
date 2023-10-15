using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour 
{
	[SerializeField] private TMP_Text nameText;
	[SerializeField] private TMP_Text dialogueText;
	[SerializeField] private Animator animator;
	[SerializeField] private MouseInteractor mouseInteractor;

	private Queue<string> sentences = new();
	
	public void StartDialogue (Dialogue dialogue)
	{
		mouseInteractor.IsInteractionOn = false;
		animator.SetBool("IsOpen", true);
		nameText.text = dialogue.Name;
		sentences.Clear();
		foreach (string sentence in dialogue.Sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	private IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	private void EndDialogue()
	{
		mouseInteractor.IsInteractionOn = true;
		animator.SetBool("IsOpen", false);
	}
}