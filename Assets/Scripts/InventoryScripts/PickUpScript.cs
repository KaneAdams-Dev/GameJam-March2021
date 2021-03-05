using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickUpScript : MonoBehaviour
{
    [SerializeField]
    InventoryScript inventory;

    // Start is called before the first frame update
    void Start()
    {
        //inventory.GetComponent<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
	/// Pickup disappears when player walks into
	/// </summary>
	/// <param name="other">The other GameObject that contains a Collider</param>
	private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            inventory.AddItem(gameObject);

            //gameObject.SetActive(false);
        }
    }
}
