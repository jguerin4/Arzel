using UnityEngine;
using System.Collections;

public class TexteMéchant : MonoBehaviour {
	
	private int counter = 0;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		counter++;
		
		if (counter == 120)
			guiText.text = "Dr. lil'K : Hééé!!!! toi qu'est-ce \r\n que tu fais la?";

		if (counter == 270)
			guiText.text = "Dr. lil'K : Tu es dans mon \r\n hood man!!!";

		if (counter == 420)
			guiText.text = "Dr. lil'K : Ici c'est moi le \r\n roi!!!";

		if (counter == 570)
			guiText.text = "Dr. lil'K : Et je fais la loi!!!";

		if (counter == 720)
			guiText.text = "Dr. lil'K : Pigé?";

		if (counter == 820)
						guiText.text = "";

		if (counter == 920)
			guiText.text = "Dr. lil'K : Tes idiot ou quoi?";

		if (counter == 1070)
			guiText.text = "Dr. lil'K : Est-ce que tu sais \r\n qui est devant toi?";

		if (counter == 1245)
			guiText.text = "Dr. lil'K : Mon nom est Dr. lil'K";

		if (counter == 1395)
			guiText.text = "Dr. lil'K : Et tu va goûter à \r\n mon crew!";

		if (counter == 1545)
			guiText.text = "Dr. lil'K : Tient un avant goût!";

		if (counter == 1645)
			guiText.text = "Dr. lil'K : POUVOIR DU HIP";

		if (counter == 1745)
						guiText.text = "";
		

		
		
	}
}
