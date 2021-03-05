using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour {

	public void Levelone() {
		SceneManager.LoadScene("MainGame");
	}
	public void Leveltwo() {
		SceneManager.LoadScene("MainGameLevel2");
	}
	public void Title() {
		SceneManager.LoadScene("Menu");
	}
	public void Exit() {
		Application.Quit();
	}

}
