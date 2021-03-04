using UnityEngine;

/// <summary>
/// Controls movement of Player GameObject using 'QWERTY' keyboard
/// Controls where Player's camera looks for mouse
/// </summary>
public class PlayerMovementScript : MonoBehaviour {
	CharacterController controller;

	// Camera variables
	private bool lockCursor = true;
	private float cameraPitch = 0.0f;
	public float mouseSensitivity = 3.5f;

	[SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.1f;
	
	Vector2 currentMouseDelta = Vector2.zero;
	Vector2 currentMouseDeltaVelocity = Vector2.zero;
	
	[SerializeField]
	Transform playerCamera;

	// Physics variables
	private float speed;
	public float defaultSpeed = 5.0f;
	public float runSpeed = 15.0f;
	
	private float gravity = -9.81f;
	private float velocityY = 0.0f;
	public float jumpHeight = 100.0f;
	
	[SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
	
	Vector2 currentDir = Vector2.zero;
	Vector2 currentDirVelocity = Vector2.zero;

	/// <summary>
	/// Assign variables to defaults
	/// </summary>
	void Start() {
		controller = GetComponent<CharacterController>();
		speed = defaultSpeed;

		if (lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	// Update is called once per frame
	void Update() {
		UpdateMouseLook();
		UpdatePlayerMovement();
	}

	void UpdateMouseLook() {
		Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

		cameraPitch -= currentMouseDelta.y * mouseSensitivity;
		cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

		playerCamera.localEulerAngles = Vector3.right * cameraPitch;
		transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
	}

	void UpdatePlayerMovement() {
		Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		targetDir.Normalize();

		currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

		if (controller.isGrounded) {
			//canJump = true;
			if (Input.GetKey(KeyCode.Space)) {
				velocityY += jumpHeight;
			} else {
				velocityY = 0.0f;
			}

			// Sprint mechanic
			// If the player is pressing the run button, then the speed increases, otherwise default speed
			if (Input.GetKey(KeyCode.LeftShift)) {
				speed = runSpeed;
			} else {
				speed = defaultSpeed;
			}
		}
		velocityY += gravity * Time.deltaTime;

		Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed + Vector3.up * velocityY;

		controller.Move(velocity * Time.deltaTime);
	}
}