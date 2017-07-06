using UnityEngine;
using System.Collections;

public class musicPlayer : MonoBehaviour {
	static musicPlayer instance = null;

	void Awake() {
	if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	// IF there is duplicate music playing then in lesson 66 it shows a reason why,
	// this can be caused by the order of function calling the compiler has.

	// Use this for initialization
	//void Start () {
		// simple conditional which test to see if there is a pointer to a 
		// a music player already, if it is null then make one, otherwise
		// destroy the possibility of another one coming around.
	//	if (instance != null) {
	//		Destroy (gameObject);
	//		print ("Keeping you good with one music player only");
	//	} else {
			// This ensures there will be only one music player and 
			// makes sure that the music player currently on will not
			// also self destruct
	//		instance = this;
	//		GameObject.DontDestroyOnLoad (gameObject);

	//	}
	//}
	
	// Update is called once per frame
	void Update () {
	
	}
}
