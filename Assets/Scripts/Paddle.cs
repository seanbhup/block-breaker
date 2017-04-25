using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector2 paddlePosition = new Vector3 (0f, this.transform.position.y, 0f);
		
		float mousePositionInBlocks = (Input.mousePosition.x / Screen.width) * 16;
//		print (mousePosInBlocks);

		paddlePosition.x = Mathf.Clamp (mousePositionInBlocks, 0f, 15f);

		this.transform.position = paddlePosition;

		

	}
}
