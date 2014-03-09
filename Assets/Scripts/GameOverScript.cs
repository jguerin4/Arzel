using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	
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
				GUI.DrawTexture(new Rect(Screen.width/2-100,3*Screen.height/4,200,250),LOGO);
		}
		
		if(clic == "")
		{
			//Buttons
			GUI.skin = myskin;
			if (GUI.Button(new Rect((Screen.width/2-100),(3*Screen.height/4),200,30), "Retourner au menu Principal"))
			{
				clic = "menuPrincipal";
			}
			
			if (GUI.Button(new Rect((Screen.width/2-100),(3*Screen.height/4+50),200,30), "Voir le classement"))
			{
				clic = "classement";
			}
			if (GUI.Button(new Rect((Screen.width/2-100),(3*Screen.height/4+100),200,30), "Quitter le jeu"))
			{
				clic = "quitter";
			}
			
		}
		else if(clic == "menuPrincipal")
		{
			Application.LoadLevel("menuPrincipal");
		}
		
		
		else if(clic == "classement")
		{
			GUIStyle classementStyleCentree = new GUIStyle(GUI.skin.GetStyle("Box"));	//Style centrée
			classementStyleCentree.alignment = TextAnchor.MiddleCenter;
			classementStyleCentree.normal.textColor = Color.green;
			classementStyleCentree.hover.textColor = Color.green;
			classementStyleCentree.active.textColor = Color.black;
			classementStyleCentree.fontSize = Screen.height/36;

			GUIStyle classementStyleAlignGauche = new GUIStyle(GUI.skin.GetStyle("Box"));
			classementStyleAlignGauche= classementStyleCentree;	//Style Alignement a gauche
			classementStyleAlignGauche.alignment = TextAnchor.UpperLeft;



			GUI.Box(new Rect(50,Screen.height/2-275,Screen.width-100,50), "Classement général du jeu:",classementStyleCentree);
			GUI.Box(new Rect(50,Screen.height/2-200,Screen.width-100,400),
			          "1. " + /*score + */ "\n"
			        + "2. " + /*score + */ "\n"
			        + "3. " + /*score + */ "\n"
			        + "4. " + /*score + */ "\n"
			        + "5. " + /*score + */ "\n"
			        + "6. " + /*score + */ "\n"
			        + "7. " + /*score + */ "\n"
			        + "8. " + /*score + */ "\n"
			        + "9. " + /*score + */ "\n"
			        + "10. " + /*score + */ "\n",classementStyleAlignGauche);
		}
		
		else if(clic == "quitter")
			Application.Quit();	
	}
	
	private void Update()
	{
		if(clic == "classement" && Input.GetKey(KeyCode.Escape))
		{
			clic = "";
		}
	}
}
