using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string Levelname){
		Debug.Log ("Level load requested for " + Levelname);
		Brick.brickCount = 0;
		Application.LoadLevel (Levelname);
	}

	public void QuitLevel(string Levelname){
		Debug.Log ("We have called quit level" + Levelname);
		Application.Quit ();
	}

	public void LoadNextLevel(){
		// This will take an int or a string.
		// The int method can take the build setting level and increment it
		// The string method can take the specificaly called level by name.
		Brick.brickCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	//This is the more correct way to detect if the level should advance.
	public void lastBrick(){
		if (Brick.brickCount <= 0) {
			LoadNextLevel ();
		} else {
		 // do nothing
		}
	}


}
