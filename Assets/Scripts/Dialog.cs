using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Dialog  {
	public Sprite imageHero;
	public string name;
	[TextArea(3,20)]
	public string[] setences;
}
