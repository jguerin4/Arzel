using UnityEngine;
using System.Collections;

public class TexteBarde : MonoBehaviour {

	private int counter = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		counter++;

		if (counter == 20)
						guiText.text = "Arzel : La la la la la";

		if (counter == 100)
						guiText.text = "";


		if (counter == 820) 
			guiText.text = "Arzel : Quoi??";

		if (counter == 920)
						guiText.text = "";

		if (counter == 1745)
			guiText.text = "Arzel : NONNNNNN!!!!!!!!!!!";

		if (counter == 1845)
			guiText.text = "Arzel : Mes cordes ont brisées";

		if (counter == 1945)
			guiText.text = "Arzel : Je vais devoir trouver des \r\n matériaux pour la réparer";

		if (counter == 2095)
			guiText.text = "Arzel : Et donner une correction à ce taquin";

		if (counter == 2200)
			guiText.text = "Arzel : La la la la";

		if (counter == 2300)
						guiText.text = "";
		if(counter == 2400)
			Application.LoadLevel("scene #1");

	}
}
