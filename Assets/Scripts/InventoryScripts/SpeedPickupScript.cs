using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickupScript : MonoBehaviour {
	public PlayerMovementScript playerMovement;

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "player") {

			playerMovement.speedMultiplier = 2;

			StartCoroutine(SpeedBoost());
		}
	}

	IEnumerator SpeedBoost() {
		playerMovement.speedMultiplier = 2;

		yield return new WaitForSeconds(5);

		playerMovement.speedMultiplier = 1;
	}
}
