using UnityEngine;
using System.Collections;

public class SphereMovement : MonoBehaviour {

	public float speed;

	void Update () {
		transform.position -= new Vector3(0f, 1f, 0f) * Time.deltaTime * speed;
	}
}
