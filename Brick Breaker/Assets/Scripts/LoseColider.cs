using UnityEngine;
using System.Collections;

public class LoseColider : MonoBehaviour {

	public int ballCount;
	public bool isBall;

	void Start(){
		isBall = (this.tag == "Ball");
		
		if (isBall) {
			ballCounter ();
		}
	}
	

	void ballCounter(){
		ballCount++;
	}


	private LevelManager levelManager;
	// If this function is called when the ball collides with the bottom of the screen then the
	// level manager will call the Win Screen.
	void OnTriggerEnter2D (Collider2D trigger) {
		//print ("Triggered on Trigger Enter 2D");
		ballCount--;
		if (ballCount <= 0) {
		// This is to sync the game for the designer to load the correct level each time
			levelManager = GameObject.FindObjectOfType<LevelManager>();
			levelManager.LoadLevel ("Lose");
		}
			// do nothing
	}

	void OnCollisionEnter2D(Collision2D collision){
		print ("onCollisionEnter2d called");
	}

}
