using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	
	public int length;
	public int level;
	private  List<items> p_inventory = new List<items>();
	public  List<items> Inventory
	{
		get{return p_inventory;}
	}
	public void erase(int i){
		Debug.Log ("erase");
		p_inventory.RemoveAt(i);
		
	}
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
		length = p_inventory.Count;
	}
}