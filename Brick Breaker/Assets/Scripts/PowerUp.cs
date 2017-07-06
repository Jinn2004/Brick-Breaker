using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {


	public GameObject NewBall;
	// Use this for initialization
	void Start () {
		Instantiate(NewBall, new Vector3(0,0,0), Quaternion.identity);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
