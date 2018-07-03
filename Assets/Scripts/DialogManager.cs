using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public Image charImage;
	public Animator animator;
	private Queue<string> setences;
	// Use this for initialization
	void Start () {
		setences = new Queue<string> (); 
	}
	public void StartDialogue(Dialog dialogue){

		animator.SetBool ("isOpen", true);
		nameText.text = dialogue.name;
		charImage.sprite = dialogue.imageHero;
		setences.Clear ();

		foreach (string setence in dialogue.setences) {
			setences.Enqueue (setence);

		}
		DisplayNextSetence ();
	}

	public void DisplayNextSetence(){
		if (setences.Count == 0) {
			EndDialogue ();
			return;
		}

		string setence = setences.Dequeue (); 
		StopAllCoroutines ();
		StartCoroutine (TypeSetence(setence));
	}

	IEnumerator TypeSetence(string setence){
		dialogueText.text = "";
		foreach (char letter in setence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue(){
		animator.SetBool ("isOpen", false);
		Debug.Log ("End Dialogue");
	}

}
