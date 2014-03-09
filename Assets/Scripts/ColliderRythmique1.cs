using UnityEngine;
using System.Collections;

public class ColliderRythmique1 : MonoBehaviour {

	private bool dejaJouer = false;				// La note a déja été jouée?
	private bool appuyerPourRien = false;
	private int collisionCount;					// Sert a savoir si on appuis sur espace sans collisions
	
	public bool enCollision = false;
	public int score;
	private string reussite;
	private GUISkin mySkin;
	public float notesReussies = 0;
	public int collisionTotal = 0;				// sert a savoir si on a jouer toutes les notes

	void Update(){
		if (collisionCount == 0 && Input.GetKeyDown("space")){
			appuyerPourRien = true;
		}
	}

	void OnGUI () 
	{
		GUIStyle rougeStyle = new GUIStyle (GUI.skin.GetStyle ("Box"));
		GUI.backgroundColor = Color.black;
		rougeStyle.normal.textColor = Color.red;
		rougeStyle.hover.textColor = Color.red;
		rougeStyle.active.textColor = Color.red;
		rougeStyle.fontSize = Screen.height / 25;
		rougeStyle.fontStyle = FontStyle.Bold;
		GUI.Box (new Rect (35*Screen.width/100, 80*Screen.height/100, 150, (Screen.height / 25)+20), reussite, rougeStyle);

	}

	void OnTriggerStay(Collider other){

		enCollision = true;
		collisionCount++;

		if (!appuyerPourRien){
			if (Input.GetKeyDown("a") && !dejaJouer){

				notesReussies++;

				if(other.transform.position.y <= (transform.position.y + 2f) && other.transform.position.y >= (transform.position.y + 1f)){
					dejaJouer = true;
					score += 10;
					reussite = "Mauvais";
					Debug.Log ("Bad");
				}
				if(other.transform.position.y <= (transform.position.y + 1f) && other.transform.position.y >= (transform.position.y + 0.5f)){
					dejaJouer = true;
					score += 30;
					reussite = "Bien";
					Debug.Log ("Good");
				}
				if(other.transform.position.y <= (transform.position.y + 0.5f) && other.transform.position.y >= (transform.position.y - 0.5f)){
					dejaJouer = true;
					score += 50;
					reussite = "Incroyable";
					Debug.Log ("Awsome");
				}
				if(other.transform.position.y <= (transform.position.y - 0.5f) && other.transform.position.y >= (transform.position.y - 1f)){
					dejaJouer = true;
					score +=30;
					reussite = "Bien";
					Debug.Log ("Good");
				}
				if(other.transform.position.y <= (transform.position.y - 1f) && other.transform.position.y >= (transform.position.y - 2f)){
					dejaJouer = true;
					score += 50;
					reussite = "Mauvais";
					Debug.Log ("Bad");
				}
				//Destroy(other.gameObject);
			}
		}
	}

	void OnTriggerExit(Collider other){
		enCollision = false;
		dejaJouer = false;
		appuyerPourRien = false;
		collisionCount--;
		collisionTotal++;
	}
}
