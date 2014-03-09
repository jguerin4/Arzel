using UnityEngine;
using System.Collections;

public class items : MonoBehaviour {
	
	private int i_type;
	private InventoryManager inventory;
	public int Type
	{
		get{ return i_type;}
	}
	// Use this for initialization
	void Start () {
		if(gameObject.name == "bois"){
			i_type = 0; 
		}
		if(gameObject.name == "metal"){
			i_type = 1;
		}
		if(gameObject.name == "tissu"){
			i_type = 2;
		}
		if(gameObject.name == "partition"){
			i_type = 3;
		}
		if(gameObject.name == "guitar"){
			i_type = 4;
		}
		
		inventory = GameObject.Find("Inventaire").GetComponent<InventoryManager>();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Personnage")
		{
			inventory.Inventory.Add (this);
			Destroy(this.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
