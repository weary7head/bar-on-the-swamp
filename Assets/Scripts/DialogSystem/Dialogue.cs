using UnityEngine;

[System.Serializable]
public struct Dialogue 
{
	public string Name;
	public Visitor Visitor;
	[TextArea(3, 10)] public string[] Sentences;
}