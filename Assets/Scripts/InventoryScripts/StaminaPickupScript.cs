using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickupScript : MonoBehaviour
{
    public PlayerMovementScript playerMovement;
    public BarScript staminaBar;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "player") {
            playerMovement.currentStamina += 10;
            staminaBar.SetStaminaBar(playerMovement.currentStamina);
		}
    }
}
