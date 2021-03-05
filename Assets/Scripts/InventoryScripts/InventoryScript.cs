using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {
	public GameObject[] items = new GameObject[3];

	public PlayerHealthScript playerHealth;
	public PlayerMovementScript playerMovement;

	public BarScript staminaBar;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		UsePickup();
	}

	public void AddItem(GameObject item) {
		bool itemAdded = false;

		for (int i = 0; i < items.Length; i++) {
			if (items[i] == null) {
				items[i] = item;
				itemAdded = true;
				item.SetActive(false);
				Debug.Log(item.name + " was added");
				break;
			}
		}

		if (!itemAdded) {
			Debug.Log("Full!");
		}
	}

	void UsePickup() {
		GameObject item1 = items[1];
		GameObject item2 = items[2];
		GameObject item3 = items[3];

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			if (item1.tag == "HealthPickup") {
				playerHealth.ReplenishHealth();
				items[1] = null;
			} else if (item1.tag == "StaminaPickup") {
				playerMovement.currentStamina += 10;
				staminaBar.SetStaminaBar(playerMovement.currentStamina);
				items[1] = null;
			} else if (item1.tag == "SpeedPickup") {
				playerMovement.runSpeed = 50;
				items[1] = null;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			if (item2.tag == "HealthPickup") {
				playerHealth.ReplenishHealth();
				items[2] = null;
			} else if (item2.tag == "StaminaPickup") {
				playerMovement.currentStamina += 10;
				items[2] = null;
				staminaBar.SetStaminaBar(playerMovement.currentStamina);
			} else if (item2.tag == "SpeedPickup") {
				playerMovement.runSpeed = 50;
				items[2] = null;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			if (item3.tag == "HealthPickup") {
				playerHealth.ReplenishHealth();
				items[3] = null;
			} else if (item3.tag == "StaminaPickup") {
				playerMovement.currentStamina += 10;
				staminaBar.SetStaminaBar(playerMovement.currentStamina);
				items[2] = null;
			} else if (item3.tag == "SpeedPickup") {
				playerMovement.runSpeed = 50;
				items[2] = null;
			}
		}
	}
}
