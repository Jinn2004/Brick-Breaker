using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public static int brickCount = 0;
	public Sprite[] hitSprites; // This is the way we store an array of sprites to change the looks at run time
	public GameObject smoke;
	public GameObject split;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	public bool isSpecial = false; // This is for the powerup bricks
	public bool isBall;
	public int ballCount = 0;

	// Use this for initialization
	void Start () {


		isBreakable = (this.tag == "Breakable" || this.tag == "PowerUp");
		// keeps tracks of the breakable bricks by counting
		if (isBreakable) {
			brickCount++;
		}
		timesHit = 0;

		// This is the private level manager used for incrementing the scences.
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col){
		// THis will allow me to use tags to organize my objects
		// in this case its organizing it by breakable or not
		//bool isBreakable = (this.tag == "Breakable");
		
		if (isBreakable) {
			HandleHits ();
		} else {
		  // Do nothing
		}

	}

	void HandleHits(){
	timesHit++;
	// This line of code will set the amount of maximum hits depending on the size of the array + 1
	// This works to help keep the data private as well as making any new brick with new qualifications
	// to have what ever the number of changes in sprites it should have to end.
	int maxHits = hitSprites.Length + 1;
	// This destoys an object on hit
	// Instead of using ++ we add this line incase its ever higher, which a superball power up can
	// perhaps increment more then one.
	if (timesHit >= maxHits) {
		brickCount--;

		// This is the code for the particle effects the smoke effect on destruction
		SmokeParticleEffect();
			if(isSpecial){
				SplitPowerUp();
			}
		Destroy (gameObject);
						
		AudioSource.PlayClipAtPoint (crack, transform.position); // This sound is for when its destroyed
		levelManager.lastBrick();  // check the game to see if the last brick was hit to load next level

		//if(brickCount <= 0){
		//Win();  // This was my way of figuring out how to goto next level, the Levelmanager should
        // store this information, check there to see the more correct way to do this 
			//}
		} else {
			LoadSprites ();
		}
	
	}

	public GameObject NewBall;
	
	void SplitPowerUp(){
		Instantiate(NewBall, new Vector3( transform.position.x, transform.position.y, 0), Quaternion.identity);
		
	}

	void SmokeParticleEffect(){

		// THis makes a smoke object at the bricks position, with the same rotation.
		//Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
		// the As Gameobject, although strange is so that it coverts the identity right
		// this is a type of casting
		GameObject smokePuff = Instantiate (smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		// So we are setting the color based on the bricks color which is accessed from the bricks data
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;  // This will increment though the list of sprites 

		// This line of code will keep the current sprite and make sure there are no invisible ones placed
		// if the sprites are not linked up correctly.
		if (hitSprites [spriteIndex]) {
			// THis line of code will use the componet for the sprites, in this game its the sprite renderer
			// THis gives it access to change
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	// TODO remove this method when we win
	void Win()
	{
		levelManager.LoadNextLevel ();
	}


	
	
}
