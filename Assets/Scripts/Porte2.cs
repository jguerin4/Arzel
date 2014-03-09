using UnityEngine;
using System.Collections;

public class Porte2 : MonoBehaviour {
	
	public GameObject inventaire;
	
	private InventoryManager inventoryManager;
	
	void Start(){
		inventoryManager = inventaire.GetComponent<InventoryManager>();
	}
	
	void OnTriggerEnter(Collider other){
		if (inventoryManager.level == 2){
			Application.LoadLevel(6);
		}
	}
}
