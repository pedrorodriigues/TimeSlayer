using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialog dialogue;
	public bool read;
	public Collider2D m_Collider;
	private void Start(){
		read = false;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (read == false) //other.gameObject.CompareTag("Player") && 
		{
			read = true;
			Debug.Log(read);
			TriggerDialogue();
			m_Collider.enabled = false;
			
		}
	}
	public void TriggerDialogue(){
		FindObjectOfType<DialogManager> ().StartDialogue (dialogue);
	}
}
