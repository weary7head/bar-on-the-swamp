using UnityEngine;

[System.Serializable]
public struct Dialogue 
{
	public string Name;
	[TextArea(3, 10)] public string[] Sentences;
}