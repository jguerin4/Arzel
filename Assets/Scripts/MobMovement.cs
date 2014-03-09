using UnityEngine;
using System.Collections;

public class MobMovement : MonoBehaviour {

	public GameObject player;
	public float speed;

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}
}
