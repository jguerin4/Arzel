using UnityEngine;
using System.Collections;

public class Porte1 : MonoBehaviour {

	public GameObject inventaire;

	private InventoryManager inventoryManager;

	void Start(){
		inventoryManager = inventaire.GetComponent<InventoryManager>();
	}

	void OnTriggerEnter(Collider other){
		if (inventoryManager.level == 1){
			Application.LoadLevel(5);
		}
	}
}
