using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		
		paddleToBallVector = this.transform.position - paddle.transform.position;
		//.337
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			// Wait for mouse press to launch
			if (Input.GetMouseButtonDown(0)) {
				this.rigidbody2D.velocity = new Vector2(2, 10);
				hasStarted = true;
			}
		}
	}
}
