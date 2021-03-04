using UnityEngine;

/// <summary>
/// This class controls the Player GameObject's health
/// </summary>
public class PlayerHealthScript : MonoBehaviour {
	public int currentHealth;
	public int maxHealth = 100;

	public BarScript healthBarScript;

	// Start is called before the first frame update
	void Start() {
		currentHealth = maxHealth;
		healthBarScript.SetMaxHealth(maxHealth);
	}

	// Update is called once per frame
	void Update() {

	}

	/// <summary>
	/// calculates the player's new health after damage has been made
	/// </summary>
	/// <param name="a_damage">Amount of damage player takes</param>
	void TakeDamage(int a_damage) {
		currentHealth -= a_damage;

		healthBarScript.SetHealthBar(currentHealth);
	}
}