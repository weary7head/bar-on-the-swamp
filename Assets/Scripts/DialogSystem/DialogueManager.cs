using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour 
{
	[SerializeField] private TMP_Text nameText;
	[SerializeField] private TMP_Text dialogueText;
	[SerializeField] private Animator animator;
	[SerializeField] private MouseInteractor mouseInteractor;
	[SerializeField] private GameObject visitorImage;
	
	private Queue<string> sentences = new();
	private Action onDialogueEnd;
	
	public void StartDialogue (Dialogue dialogue, Action dialogueEnded)
	{
        onDialogueEnd = null;
		mouseInteractor.IsInteractionOn = false;
		animator.gameObject.SetActive(true);
		visitorImage.GetComponent<Image>().sprite = dialogue.Visitor.visitorSprite;
		animator.SetBool("IsOpen", true);
		nameText.text = dialogue.Name;
		sentences.Clear();
		foreach (string sentence in dialogue.Sentences)
		{
			sentences.Enqueue(sentence);
		}
        onDialogueEnd = dialogueEnded;
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
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
		onDialogueEnd?.Invoke();
		mouseInteractor.IsInteractionOn = true;
		animator.SetBool("IsOpen", false);
	}
}