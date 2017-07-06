using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	// this is how you declare access to another classes data
	private Paddle paddle;
	private bool hasStarted = false;

	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		// This will find the paddle every time you make a new level so that you do no need
		// the designer to link it together each time they use the pre fabricated folder
		paddle = GameObject.FindObjectOfType<Paddle>();
		// This line of code will do vector math
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {

		if (!hasStarted) {
			// This game object is set to its former self + the offset.
			// Locks the ball to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// mouse click to start
			// If the mouse is pressed down then we will start the game and launch a ball
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (5f, 5f);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D collision){
		audio.Play ();
		// add some randomness to the ball so there are no infinite loops of boredom
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range(0f, 0.2f));
		rigidbody2D.velocity += tweak;
	}
}
