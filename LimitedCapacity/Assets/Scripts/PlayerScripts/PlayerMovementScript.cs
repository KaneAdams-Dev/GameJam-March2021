using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls movement of Player GameObject using 'QWERTY' keyboard
/// </summary>
public class PlayerMovementScript : MonoBehaviour {
	// Physics variables to control movement
	// Private
	private bool isGrounded = true; // Can the player jump again?
	private float speed;
	// Public
	public float defaultSpeed = 5.0f;
	public float runSpeed = 15.0f;
	public float jumpHeight = 10.0f;

	public Rigidbody rigidBody;

	/// <summary>
	/// Assign variables to defaults
	/// </summary>
	void Start() {
		rigidBody = gameObject.GetComponent<Rigidbody>();
		speed = defaultSpeed;
	}

	// Update is called once per frame
	void Update() {
		PlayerMovement();
	}

	/// <summary>
	/// When the Player comes in contact with the Floor GameObject, jump is reset
	/// Checks whether the player can jump
	/// </summary>
	/// <param name="collision">The GameObject that has bee triggered by the Player GameObject</param>
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Floor" && !isGrounded) {
			isGrounded = true;
		}
	}

	private void PlayerMovement() {
		// Sprint mechanic
		// If the player is pressing the run button, then the speed increases, otherwise default speed
		if (Input.GetKey(KeyCode.LeftShift)) {
			speed = runSpeed;
		} else {
			speed = defaultSpeed;
		}

		// Walking mechanics
		// If the player is pressing a movement button, move in that direction
		if (Input.GetKey(KeyCode.W))    // Forwards
		{
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, speed);
		}
		if (Input.GetKey(KeyCode.A))    // Left
		{
			rigidBody.velocity = new Vector3(-speed, rigidBody.velocity.y, rigidBody.velocity.z);
		}
		if (Input.GetKey(KeyCode.S))    // Backwards
		{
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -speed);
		}
		if (Input.GetKey(KeyCode.D))    // Right
		{
			rigidBody.velocity = new Vector3(speed, rigidBody.velocity.y, rigidBody.velocity.z);
		}

		// Jump mechanic
		// If the player is pressing the jump button and the player is touching the floor, then jump
		if (Input.GetKey(KeyCode.Space) && isGrounded) {
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpHeight, rigidBody.velocity.z);
			isGrounded = false;
		}
	}
}