using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour {

	public GameObject mob1;
	public GameObject mob2;
	public GameObject mob3;
	public GameObject mob4;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Personnage"){
			mob1.SetActive(true);
			mob2.SetActive(true);
			mob3.SetActive(true);
			mob4.SetActive(true);

		}
	}
}
