using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour 
{
	private Transform myTransform;				// this transform
	private Vector3 destinationPosition;		// The destination Point
	private float destinationDistance;			// The distance between myTransform and destinationPosition
	private float destinationAngle;
	private ManageHealth manageHealth;
	
	public float moveSpeed;						// The Speed the character will move
	public GameObject ennemi;

	
	/// <summary>
	/// Déclaration Variables pour animations
	/// </summary>
	
	public float FPS;
	private float secondsToWait;
	public Texture[] textureMarcheDroite;
	public Texture[] textureMarcheGauche;
	public Texture textureMarcheHaut;
	public Texture textureMarcheBas;
	public Texture[] textureAttaqueDroite;
	public Texture[] textureAttaqueGauche;
	public Texture textureIddle;
	private bool Loop;
	
	private string animationState;
	private int currentFrame;
	private bool attaqueEnCours = false;
	
	private string stateMachine;
	
	private bool menuForgeronActif;
	
	
	
	void Start () {
		manageHealth = gameObject.GetComponent<ManageHealth>();
		myTransform = transform;							// sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;			// prevents myTransform reset
		
		//Pour les animations
		currentFrame = 0;
		secondsToWait = 1/FPS;
		stateMachine = "iddle";
	}
	
	IEnumerator Animate()
		
	{
		bool stop = false;
		
		if(Loop == false)
			stop = true;
		
		//////////
		/// Si on est a la fin du tableau, on recommence celui-ci
		/// //////

		yield return new WaitForSeconds(secondsToWait);	//On attend

		if(currentFrame >= textureMarcheDroite.Length-1 && animationState == "marcheDroite")
			currentFrame = 0;
		if(currentFrame >= textureMarcheGauche.Length && animationState == "marcheGauche")
			currentFrame = 0;
		
		if(currentFrame >= textureAttaqueDroite.Length && animationState == "attaqueDroite")	//Si on fini notre attaque
		{
			currentFrame = 0;
		}
		if(currentFrame >= textureAttaqueGauche.Length && animationState == "attaqueGauche")
		{
			currentFrame = 0;
		}
		

		
		switch (animationState)
		{
		case "marcheDroite": 
			renderer.material.mainTexture = textureMarcheDroite[currentFrame];
			break;
		case "marcheGauche": 
			renderer.material.mainTexture = textureMarcheGauche[currentFrame];
			break;
		case "marcheHaut": 
			renderer.material.mainTexture = textureMarcheHaut;
			break;
		case "marcheBas": 
			renderer.material.mainTexture = textureMarcheBas;
			break;
		case "attaqueDroite":
			renderer.material.mainTexture = textureAttaqueDroite[currentFrame];
			break;
		case "attaqueGauche":
			renderer.material.mainTexture = textureAttaqueGauche[currentFrame];
			break;
		case "iddle":
			renderer.material.mainTexture = textureIddle;
			break;
		}
		
		currentFrame++; //Pour changer de texteure lors de la prochaine itération.
		
		if(stop == false)
			StartCoroutine(Animate());
		
	}
	
	
	void Update () {
		
		// keep track of the distance between this gameObject and destinationPosition
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
		Vector3 maDestination = destinationPosition - myTransform.position;
		Vector3 source = myTransform.forward;
		
		if(transform.position.y > 3 || transform.position.y <3)
		{
			transform.position = new Vector3(transform.position.x,3f,transform.position.z);
		}
		
		destinationAngle = Vector3.Angle(maDestination, source);
		
		
		
		if(destinationDistance < .5f){		// To prevent shakin behavior when near destination
			moveSpeed = 0;
		}
		else if(destinationDistance > .5f){			// To Reset Speed to default
			moveSpeed = 20;
		}
		
		if(Input.GetKeyDown(KeyCode.Space))	
		{
			//Gestion animation
			
			attaqueEnCours = true;
			
			//Attaque d'un ennemi
			
			if(ennemi != null)
			{
				Destroy(ennemi.gameObject);
				ennemi = null;
			}
			
		}
		
		if(Input.GetKeyUp(KeyCode.Space))
		{
			attaqueEnCours = false;
		}
		
		//////////////////////////////////////////////////////////////////
		/// Gestion du stateMachine
		/// //////////////////////////////////////////////////////////////
		
		if(attaqueEnCours == true)
		{
			if(maDestination.x >= source.x)
			{
				stateMachine = "attaqueDroite";
			}
			else if(maDestination.x < source.x)
			{
				stateMachine = "attaqueGauche";
			}
			
		}
		
		else if(moveSpeed <= 5)
		{
			stateMachine = "iddle";
		}
		
		else if( (destinationAngle <= 45) )
		{
			//if(moveSpeed >= 1)
			stateMachine = "marcheHaut";
			/*else
				stateMachine = "finMarcheHaut";*/
		}
		
		else if( destinationAngle >= 135)
		{
			//if(moveSpeed >= 1)
			stateMachine = "marcheBas";
			/*else
				stateMachine = "finMarcheBas";*/
		}
		
		else if( maDestination.x >= source.x)
		{
			//if(moveSpeed >= 1)
			stateMachine = "marcheDroite";
			/*else
				stateMachine = "finMarcheDroite";*/
		}
		
		else if( (maDestination.x <= source.x) )
		{
			//if(moveSpeed >= 1)
			stateMachine = "marcheGauche";
			/*else
				stateMachine = "finMarcheGauche";*/
		}
		else 
		{
			stateMachine = "iddle";
		}
		
		
		
		//////////////////////////////////////////////////////////////////
		/// Fin Gestion du stateMachine
		/// //////////////////////////////////////////////////////////////
		
		//////////////////////////////////////////////////////////////////
		/// Est-ce qu'on est dans le menu du forgeron?
		//////////////////////////////////////////////////////////////////
		
		
		// Moves the Player if the Left Mouse Button was clicked
		if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0) {
			
			Plane playerPlane = new Plane(Vector3.up, myTransform.position);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float hitdist = 0.0f;
			
			if (playerPlane.Raycast(ray, out hitdist)) {
				Vector3 targetPoint = ray.GetPoint(hitdist);
				destinationPosition = ray.GetPoint(hitdist);
				//Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				//myTransform.rotation = targetRotation;
			}
		}
		
		// To prevent code from running if not needed
		if(destinationDistance > .5f){
			myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
		}
		
		
		/////////////////////////////////////////
		/// Gestion des animations
		/// /////////////////////////////////////
		
		if(stateMachine == "attaqueDroite")	//Déplacement a droite
		{
			animationState = "attaqueDroite";
			Loop = true;	
			StartCoroutine(Animate ());
			
		}
		
		if(stateMachine == "attaqueGauche")	//Déplacement a droite
		{
			animationState = "attaqueGauche";
			Loop = true;	
			StartCoroutine(Animate ());
			
		}
		
		else if(stateMachine == "marcheDroite")//Appuie fleche gauche
		{
			animationState = "marcheDroite";
			Loop = true;	
			StartCoroutine(Animate ());
		}
		
		else if(stateMachine == "marcheGauche")//Appuie fleche gauche
		{
			animationState = "marcheGauche";
			Loop = true;	
			StartCoroutine(Animate ());
		}
		
		
		else if(stateMachine == "marcheHaut")//Appuie fleche gauche
		{
			animationState = "marcheHaut";
			Loop = true;	
			StartCoroutine(Animate ());
		}
		
		else if(stateMachine == "marcheBas")//Appuie fleche gauche
		{
			animationState = "marcheBas";
			Loop = true;	
			StartCoroutine(Animate ());
		}
		
		
		
		else if(stateMachine == "iddle")
		{
			Loop = false;	
			currentFrame = 0;
			StopCoroutine("Animate ()");
			
		}
		
		
	}
	
	void OnTriggerEnter(Collider other){
		if (other.name == "Health"){
			Destroy (other.gameObject);
			manageHealth.ajusteCurrentHealth(20);
		}
	}	
	

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Mob")
		{
			ennemi = other.gameObject;
		}
	}
	/// <summary>
	/// Raises the trigger exit event.
	/// </summary>
	/// <param name="other">Other.</param>
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Mob")
		{
			ennemi = null;
		}
	}
	
	
	
}