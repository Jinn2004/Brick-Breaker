using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay = false;
	private Ball ball;

	void Start(){
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	// Update is called once per frame
	void Update () {
		if (autoPlay != true) {
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
		
	}

	void AutoPlay(){
		Vector3 paddlePosition = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPosition = ball.transform.position;
		paddlePosition.x = Mathf.Clamp(ballPosition.x, 0.79f, 15.22f);
		this.transform.position = paddlePosition;
	
	}

	void MoveWithMouse(){
		// this line of code will log on the console where ever the mouse position is
		// starting from the bottom left corner of the screen being (0,0,0) or (x,y,z)
		//print (Input.mousePosition);   // log all of the coordinates
		//print (Input.mousePosition.x); // log only the x corrdinates
		//print (Input.mousePosition.y); // log only the y coordiantes
		// I would imagine this would work for the z coordinates as well for 3D
		
		// This will log the floating point number of x to the number of 0 on the rhs, and 1 on the lhs
		// whereas on any screen with this line of code will have .5 in the middle of the screens X coord.
		//print (Input.mousePosition.x / Screen.width);
		// This line of code is used for Brick breaker.  this is multiplied by 16 because of the amount
		// of units that the width of the screen has.  8 should be the middle, and lhs = 0, and rhs = 16
		//print (Input.mousePosition.x / Screen.width * 16);
		
		
		// Using Vector 3 we can have a x,y,z coordinate system for the game
		// In the parameters there is a number and then a letter, f stands for a float
		// therefore the f is nessicary although odd in c++ circumstances
		
		// X : this is the x horizon floating point number corrdinate
		// Y : this line of code is to keep the position it is placed on the screen to be
		//     the same as where it was placed instead of setting it to a new place.
		// Z : This is simlar to X.
		Vector3 paddlePosition = new Vector3 (0.5f, this.transform.position.y, 0f);
		
		float xMousePositionInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		// this line of code follows the mouse on the X Coordinate
		// The error with this line of code is that it will go off of the screen
		//paddlePosition.x = xMousePositionInBlocks;
		
		// This line of code will constrain the mouse to a minimum and maximum part of the screen.
		// The parameters are the objects to be constrianed, min, max.
		paddlePosition.x = Mathf.Clamp(xMousePositionInBlocks, 0.79f, 15.22f);
		
		// This is the paddle script object
		this.transform.position = paddlePosition;
	}
}
