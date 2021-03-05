using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour {
	public PlayerHealthScript playerHealth;

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "player") {
			playerHealth.ReplenishHealth();
		}
	}
}
