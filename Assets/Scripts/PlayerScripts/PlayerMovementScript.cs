using System.Collections;
using UnityEngine;

/// <summary>
/// Controls movement of Player GameObject using 'QWERTY' keyboard
/// Controls where Player's camera looks for mouse
/// </summary>
public class PlayerMovementScript : MonoBehaviour {
	[SerializeField]
	InventoryScript inventory;

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
	private bool isStuck = false;
	private float speed;
	public float defaultSpeed = 10.0f;
	public float runSpeed = 20.0f;
	public float currentStamina;
	public float maxStamina = 100f;
	public float speedMultiplier = 1;

	private float gravity = -9.81f;
	private float velocityY = 0.0f;
	public float jumpHeight = 20.0f;

	[SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;

	Vector2 currentDir = Vector2.zero;
	Vector2 currentDirVelocity = Vector2.zero;

	public BarScript staminaBar;
	public PlayerHealthScript healthScript;

	/// <summary>
	/// Assign variables to defaults
	/// </summary>
	void Start() {
		controller = GetComponent<CharacterController>();
		speed = defaultSpeed;
		currentStamina = maxStamina;
		staminaBar.SetMaxStamina(maxStamina);

		if (lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	// Update is called once per frame
	void Update() {
		UpdateMouseLook();
		if (!isStuck) {
			UpdatePlayerMovement();
		}
	}

	/// <summary>
	/// Changes where the player looks depending on where mouse is
	/// </summary>
	void UpdateMouseLook() {
		Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

		currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

		cameraPitch -= currentMouseDelta.y * mouseSensitivity;
		cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

		playerCamera.localEulerAngles = Vector3.right * cameraPitch;
		transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
	}

	/// <summary>
	/// Changes where the player is in the game world
	/// </summary>
	void UpdatePlayerMovement() {
		Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		targetDir.Normalize();

		currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

		if (controller.isGrounded) {
			if (Input.GetKey(KeyCode.Space) && currentStamina > 0) {
				velocityY += jumpHeight;
				currentStamina--;
				staminaBar.SetStaminaBar(currentStamina);
			} else {
				velocityY = 0.1f;
			}

			// Sprint mechanic
			// If the player is pressing the run button, then the speed increases, otherwise default speed
			if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0) {
				speed = runSpeed;
				currentStamina -= 0.01f;
				staminaBar.SetStaminaBar(currentStamina);
			} else {
				speed = defaultSpeed;
			}
		}
		velocityY += gravity * Time.deltaTime;

		Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed * speedMultiplier + Vector3.up * velocityY;

		controller.Move(velocity * Time.deltaTime);
	}

	/// <summary>
	/// When the player enters a trap, they will become stuck
	/// </summary>
	/// <param name="other">Used to see if other object is a trap</param>
	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Trap") {
			healthScript.TakeDamage(15);
			isStuck = true;
			StartCoroutine(StuckInTrap());
		}
	}

	/// <summary>
	/// Player is unstuck after 5 seconds
	/// </summary>
	/// <returns>Waits 5 seconds before continuing</returns>
	IEnumerator StuckInTrap() {
		yield return new WaitForSeconds(5);

		isStuck = false;
	}
}