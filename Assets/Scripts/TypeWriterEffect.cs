using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{

	public float delay = 0.1f;
	private string fullText;
	private string currentText = "";
	public AudioSource source;

	// Use this for initialization
	void Start()
	{
		fullText = this.GetComponent<Text>().text;
		StartCoroutine(ShowText());
	}

	IEnumerator ShowText()
	{
		for (int i = 0; i < fullText.Length; i++)
		{
			currentText = fullText.Substring(0, i);
			this.GetComponent<Text>().text = currentText;
			source.Play();
			yield return new WaitForSeconds(delay);
		}
	}
}
