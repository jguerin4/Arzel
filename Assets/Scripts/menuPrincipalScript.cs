using UnityEngine;
using System.Collections;

public class menuPrincipalScript : MonoBehaviour {


	private GUISkin myskin;
	public Texture2D background, LOGO;
	
	
	
	private string clic = "";
	
	private void OnGUI()
	{
		//Background
		if(background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),background);
		
		if(clic == "" || clic == "propos")
		{
			//LOGO
			if(LOGO != null)
				GUI.DrawTexture(new Rect(Screen.width/4-100, (55*Screen.height/100),80,125),LOGO);
		}
		
		if(clic == "")
		{
			//Buttons
			GUI.skin = myskin;
			if (GUI.Button(new Rect((Screen.width/2-100),(Screen.height/2),200,30), "Jouer"))
			{
				clic = "jouer";
			}
			
			if (GUI.Button(new Rect((Screen.width/2-100),(Screen.height/2+50),200,30), "À Propos"))
			{
				clic = "propos";
			}
			if (GUI.Button(new Rect((Screen.width/2-100),(Screen.height/2+100),200,30), "Quitter le jeu"))
			{
				clic = "quitter";
			}
			
		}
		else if(clic == "jouer")
		{
			Application.LoadLevel("Intro");
		}
		
		
		else if(clic == "propos")
		{
			GUIStyle proposStyle = new GUIStyle(GUI.skin.GetStyle("Box"));
			proposStyle.alignment = TextAnchor.MiddleCenter;
			proposStyle.normal.textColor = Color.green;
			proposStyle.hover.textColor = Color.green;
			proposStyle.active.textColor = Color.green;
			proposStyle.fontSize = Screen.height/36;
			GUI.Box(new Rect(50,Screen.height/2-75,Screen.width-100,50), "Déplacement: Appuyez sur le bouton gauche de la souris sur l'écran pour vous déplacer",proposStyle);
			GUI.Box(new Rect(50,Screen.height/2,Screen.width-100,50), "Appuyer sur espace pour attaquer",proposStyle);
			GUI.Box(new Rect(50,Screen.height/2+75,Screen.width-100,200), "Commande de la partie rythmique" + "\n"
			        													+ "a pour jouer la premiere corde" + "\n"
			        													+ "s pour jouer la deuxieme corde" + "\n"
			        													+ "d pour jouer la troisieme corde",proposStyle);
		}
		
		else if(clic == "quitter")
			Application.Quit();	
	}
	
	private void Update()
	{
		if(clic == "propos" && Input.GetKey(KeyCode.Escape))
		{
			clic = "";
		}
	}
	
}
