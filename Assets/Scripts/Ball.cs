using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	
	private bool gameStarted = false;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
	
		paddleToBallVector = this.transform.position - paddle.transform.position;
//		print (paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameStarted){
//			lock the ball relative To the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
//			WaitForSeconds for as mouse press To launch
			if (Input.GetMouseButtonDown(0)){
				print ("mouse clicked, launch ball");
				gameStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}	
		
	}
}
