using UnityEngine;
using System.Collections;

public class CodePourMusique1 : MonoBehaviour {


	public AnimationCurve curve;
	public GameObject Corde1;
	private string etat= "";
	private int monScore;

	private ColliderRythmique1 rythmique1;
	private int totalNotes = 30;

	// Use this for initialization
	void Start () {

		rythmique1 = Corde1.GetComponent<ColliderRythmique1>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(curve.Evaluate (Time.time).ToString());
		if (rythmique1.collisionTotal == totalNotes){
			Time.timeScale = 0;
			Debug.Log ((rythmique1.notesReussies) / totalNotes * 100 + "%");
			Debug.Log (rythmique1.score  + " points");
			monScore = rythmique1.score;
			etat = "fin";
		}
	}

	void OnGUI()
	{
		if(etat == "")	//On faite rien
		{}
		if(etat == "fin")
		{
			GUI.Box (new Rect (35*Screen.width/100, (80*Screen.height/100)+30, 75*Screen.width/100, (Screen.height / 25)+20),"Vous avez obtenu un score de : " +  monScore.ToString());

		}

	}


}

