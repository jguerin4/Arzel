﻿using UnityEngine;
using System.Collections;

public class CodePourMusique3 : MonoBehaviour {
	
	public GameObject Corde1;
	public GameObject Corde2;
	public GameObject Corde3;
	public Texture2D backgroudButton;
	

	private ColliderRythmique1 rythmique1;
	private ColliderRythmique2 rythmique2;
	private ColliderRythmique3 rythmique3;
	private int totalNotes = 104;

	private string etat= "";
	private int monScore;
	private float pourcentage;
	
	void Start(){
		rythmique1 = Corde1.GetComponent<ColliderRythmique1>();
		rythmique2 = Corde2.GetComponent<ColliderRythmique2>();
		rythmique3 = Corde3.GetComponent<ColliderRythmique3>();
	}
	
	void Update(){
		if (rythmique1.collisionTotal + rythmique2.collisionTotal + rythmique3.collisionTotal == totalNotes)
		{
			Time.timeScale = 0;
			//Debug.Log ((rythmique1.notesReussies + rythmique2.notesReussies + rythmique3.notesReussies) / totalNotes * 100 + "%");
			//Debug.Log (rythmique1.score + rythmique2.score + rythmique3.score + " points");

			monScore = rythmique1.score + rythmique2.score + rythmique3.score;
			pourcentage = (rythmique1.notesReussies + rythmique2.notesReussies + rythmique3.notesReussies) / totalNotes * 100;

			if(pourcentage >= 75 && etat == "")
			{
				etat = "finVictoire";
			}

			else if(pourcentage < 75 && etat == "")
			{
				etat = "finDefaite";
			}
		}
	}

	
	void OnGUI()
	{
		if(etat == "")	//On faite rien
		{}
		else if(etat == "finVictoire")
		{
			GUI.DrawTexture(new Rect(((35*Screen.width/100)),(25*Screen.height/100),40*Screen.width/100,100),backgroudButton);
			if(GUI.Button(new Rect(((35*Screen.width/100)),(25*Screen.height/100),40*Screen.width/100,100), "Félicitation! vous pouvez passez au niveau suivant!" + "\n" + "Pourcentage: " + pourcentage.ToString() + "\n" + "Appuyez ici pour continuer"))
			{
				etat = "switchWin";
			}
			GUI.DrawTexture(new Rect(35*Screen.width/100, (80*Screen.height/100)+45, 40*Screen.width/100, (Screen.height / 25)+20),backgroudButton);
			GUI.Box (new Rect (35*Screen.width/100, (80*Screen.height/100)+45, 40*Screen.width/100, (Screen.height / 25)+20),"Vous avez obtenu un score de : " +  monScore.ToString());
			Debug.Log("finVictoire2 ---- " + etat );
		}

		else if(etat == "finDefaite")
		{
			GUI.DrawTexture(new Rect(((35*Screen.width/100)),(25*Screen.height/100),40*Screen.width/100,100),backgroudButton);
			GUI.DrawTexture(new Rect(35*Screen.width/100, (80*Screen.height/100)+45, 40*Screen.width/100, (Screen.height / 25)+20),backgroudButton);
			GUI.Box (new Rect (35*Screen.width/100, (80*Screen.height/100)+45, 40*Screen.width/100, (Screen.height / 25)+20),"Vous avez obtenu un score de : " +  monScore.ToString());
			if(GUI.Button(new Rect(((35*Screen.width/100)),(25*Screen.height/100),40*Screen.width/100,100), "ésolé. vous ne pouvez pas passez au niveau suivant!" + "\n" + "Pourcentage: " + pourcentage.ToString() +"\n" + "Appuyez ici pour retourner au menu principal"))
			{
				etat = "switchMenu";
			}

		}
		else if(etat == "switchWin")
		{
			Application.LoadLevel("WinScene");
		}
		else if(etat == "switchMenu")
		{
			Application.LoadLevel("GameOver");
		}

		
	}

}
