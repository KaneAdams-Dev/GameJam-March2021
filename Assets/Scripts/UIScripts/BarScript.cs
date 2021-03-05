using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class changes the health and stamina bars to fit the player's health and stamina respectively
/// </summary>
public class BarScript : MonoBehaviour {
	public Slider healthSlider;
	public Slider staminaSlider;

	/// <summary>
	/// Sets the max value for the health bar
	/// </summary>
	/// <param name="a_health">Amount of health</param>
	public void SetMaxHealth(int a_health) {
		healthSlider.maxValue = a_health;
		healthSlider.value = a_health;
	}

	/// <summary>
	/// Set the max value for the stamina bar
	/// </summary>
	/// <param name="a_stamina">Amount of stamina</param>
	public void SetMaxStamina(float a_stamina) {
		staminaSlider.maxValue = a_stamina;
		staminaSlider.value = a_stamina;
	}

	/// <summary>
	/// Sets the value for health bar currently
	/// </summary>
	/// <param name="a_health">Amount of health</param>
	public void SetHealthBar(int a_health) {
		healthSlider.value = a_health;
	}

	/// <summary>
	/// Sets the value for stamina bar currently
	/// </summary>
	/// <param name="a_stamina">Amount of stamina</param>
	public void SetStaminaBar(float a_stamina) {
		staminaSlider.value = a_stamina;
	}
}