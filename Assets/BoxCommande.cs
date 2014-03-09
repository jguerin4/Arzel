using UnityEngine;
using System.Collections;

public class BoxCommande : MonoBehaviour {
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,120), "Touche");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Corde 1 = a")) {
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Corde 2 = s")) {
		}

		if(GUI.Button(new Rect(20,100,80,20), "Corde 3 = d")) {
		}
	}
}