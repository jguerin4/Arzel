using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {

	public Transform loot;

	private GameObject health;
	private GameObject mob;
	private Vector3 positionMob;
	private float lootChance;

	void Start(){
		mob = gameObject;
		loot = gameObject.transform.GetChild(1);
		health = loot.gameObject;
	}

	void Update(){
		health.transform.position = mob.transform.position;
	}

	void OnDestroy(){
		health.transform.parent = null;
		lootChance = Random.value * 100;

		if (lootChance <= 25){
			health.SetActive(true);
		}
	}
}
