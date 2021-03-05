using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {
	public GameObject[] items = new GameObject[3];

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

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
}
