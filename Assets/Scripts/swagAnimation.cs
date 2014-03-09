using UnityEngine;
using System.Collections;

public class swagAnimation : MonoBehaviour 
{
	private bool droite;
	public float smooth = 3f;
	public GameObject player;

	private Vector3 newPosition;
	
	public Texture[] textureSwagDroite;
	public Texture[] textureSwagGauche;
	
	public float FPS;
	private float secondsToWait;

	
	private int currentFrame;
	
		void Start ()
	{
		currentFrame = 0;
		secondsToWait = 1/FPS;
		StartCoroutine(Animate());

		droite = false;
	}
	
	
	void Update()
	{
		ChangerBool ();
	}
	
	void ChangerBool()
	{	
		if(transform.position.x - player.transform.position.x >= 0f)
		{
			droite = true;
		}
		
		if(transform.position.x - player.transform.position.x <= 0f)
		{
			droite = false;
		}
	}
		
	
	IEnumerator Animate()
	{
		if(currentFrame >= textureSwagDroite.Length && droite)
			currentFrame = 0;
		if(currentFrame >= textureSwagGauche.Length && !droite)
			currentFrame = 0;
		
		yield return new WaitForSeconds(secondsToWait);
		
		switch (droite)
		{
		case true: 
			renderer.material.mainTexture = textureSwagGauche[currentFrame];
			break;
		case false:
			renderer.material.mainTexture = textureSwagDroite[currentFrame];
			break;
		}
				
		currentFrame++;
		
		StartCoroutine(Animate());
		
		
	}
	
	
}
