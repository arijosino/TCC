using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {
	public TextAsset dialogSource;
	string[] dialogLines;
	public int currentDialogLine = 0;
	public bool startOnCollision;
	public bool destroyWhenFinished;

	private bool hasSomethingToSay;
	public bool HasSomethingToSay{ 
		get{
			return hasSomethingToSay;
		}
	}
	public bool repeatsText;

	// Use this for initialization
	void Start () {
		// Make sure there this a text
		// file assigned before continuing
		if(dialogSource != null)
		{
			this.hasSomethingToSay = true;
			// Add each line of the text file to
			// the array using the new line
			// as the delimiter
			dialogLines = ( dialogSource.text.Split( '\n' ) );
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(startOnCollision && other.tag == "Player" && hasSomethingToSay && other.GetComponent<Movement>().enabled){
			other.GetComponent<MainCharacter>().startDialog(this);
		}
	}
	public bool finishedTalking(){
		if (!repeatsText) {
			this.hasSomethingToSay = false;
		}
		return (currentDialogLine >= dialogLines.Length);
	}
	public string printNextLine(){
//		Debug.Log (dialogLines[currentDialogLine++]);
		return dialogLines [currentDialogLine++];
	}
	public void resetText(){
		currentDialogLine = 0;
	}
}
