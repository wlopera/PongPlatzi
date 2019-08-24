using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

public Transform paddle;
public bool gameStarted = false;
public Rigidbody2D rbBall; 
float posDif;

public AudioSource ballAudio;

	// Use this for initialization
	void Start () {
		posDif = paddle.position.x - transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		if (!gameStarted) {
			
			transform.position = new Vector3(paddle.position.x - posDif, paddle.position.y, paddle.position.z); 

			if(Input.GetMouseButtonDown(0)) {
				rbBall.velocity = new Vector2(9,9);
				gameStarted = true;
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D other) {
		ballAudio.Play();
	}
}
