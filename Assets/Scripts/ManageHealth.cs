using UnityEngine;
using System.Collections;

public class ManageHealth : MonoBehaviour {

	public int currentHealth = 100;
	public int maxHealth = 100;
	public float healthBarLength;

	void Start(){
		healthBarLength = Screen.width/2;
	}


	void OnTriggerEnter(Collider other){
		if(other.name == "Collider_Mob"){
			ajusteCurrentHealth(-10);
		}
	}

	void Update()
	{
		if (currentHealth <= 0)
		{
			Application.LoadLevel("GameOver");
		}
	}

	void OnGUI()
	{
		GUI.Box(new Rect(85*Screen.width/200,25*Screen.height/100,healthBarLength/4,20),"");
		GUI.Box(new Rect(85*Screen.width/200,25*Screen.height/100,Screen.width/8,20),currentHealth.ToString() + "/" + maxHealth.ToString());
	}

	public void ajusteCurrentHealth(int ajust)
	{
		currentHealth += ajust;

		if(currentHealth<0)
			currentHealth = 0;
		if(currentHealth > maxHealth)
			currentHealth = maxHealth;
		if(maxHealth < 1)
			maxHealth = 1;
		healthBarLength = (Screen.width / 2) * ( currentHealth / (float)maxHealth);

		if (healthBarLength < 50)
			healthBarLength = 50;

	}


}
