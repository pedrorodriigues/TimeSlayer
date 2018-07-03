using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialog dialogue;
	public void TriggerDialogue(){
		FindObjectOfType<DialogManager> ().StartDialogue (dialogue);
	}
}
