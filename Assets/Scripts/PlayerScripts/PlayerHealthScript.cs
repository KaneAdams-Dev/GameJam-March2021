using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class controls the Player GameObject's health
/// </summary>
public class PlayerHealthScript : MonoBehaviour {
	private bool isGameOver;
	public int currentHealth;
	public int maxHealth = 100;

	public BarScript healthBar;
	public GameObject gameOver;

	// Start is called before the first frame update
	void Start() {
		isGameOver = false;
		Time.timeScale = 1;

		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	// Update is called once per frame
	void Update() {
		// Resets the level if the game is over and player clicks to restart
		if (Input.GetKey(KeyCode.R) && isGameOver) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	/// <summary>
	/// calculates the player's new health after damage has been made
	/// </summary>
	/// <param name="a_damage">Amount of damage player takes</param>
	public void TakeDamage(int a_damage) {
		currentHealth -= a_damage;
		healthBar.SetHealthBar(currentHealth);

		// If player's health is 0 or below, game ends
		if (currentHealth <= 0) {
			GameOver();
		}
	}

	/// <summary>
	/// Replenishes 10 health (or until at 100 health)
	/// </summary>
	public void ReplenishHealth() {
		for (int i = 0; i < 10; i++) {
			if (currentHealth == maxHealth) {
				break;
			} else {
				currentHealth++;
				healthBar.SetHealthBar(currentHealth);
			}
		}
	}

	/// <summary>
	/// Creates a Game Over! screen and freezes game
	/// </summary>
	void GameOver() {
		gameOver.SetActive(true);
		isGameOver = true;
		Time.timeScale = 0;
	}
}