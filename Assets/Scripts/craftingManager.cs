using UnityEngine;
using System.Collections;

public class craftingManager : MonoBehaviour {

	public Texture2D Bois,Metal,Tissu,Partition,Guitar,Corde;
	private bool onCollision = false;
	private InventoryManager inventory;

	private bool combineDone = false;
	//Menu du forgeron
	private bool openCraftMenu = false;
	//item a crafter
	private int craftChoice = 1; 
	//inventaire
	private int bois,metal,tissu,partition,guitar;
	//valeur a crafter
	private int c_bois,c_metal,c_tissu,c_partition,c_guitar;
	private int tBois,tMetal,tTissu,tPartition,tGuitar;
	//button
	bool _bois,_metal,_tissu,_partition,_guitar,_next,_prec,_combine,_quitter;
	bool _c_bois,_c_metal,_c_tissu,_c_partition,_c_guitar;

	private string clicked = "";
	private string msg = "";
	// Use this for initializationS
	void Start () {
		inventory = inventory = GameObject.Find("Inventaire").GetComponent<InventoryManager>();
		DontDestroyOnLoad(this);

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Personnage"){
			onCollision = true;
		}
	}
	private void OnGUI(){

		int left = 200;
		int top = 10;

		GUIStyle proposStyle = new GUIStyle(GUI.skin.GetStyle("Box"));
		proposStyle.alignment = TextAnchor.MiddleCenter;
		proposStyle.fontSize = 20;

		GUIStyle boxStyle = new GUIStyle(GUI.skin.GetStyle("Box"));
		boxStyle.fontSize = 35;
		boxStyle.fontStyle = FontStyle.Bold;



		if(onCollision)
			GUI.TextArea(new Rect((Screen.width/2-100),(Screen.height/2+50),200,30),"Intéragir 'i'");
		if(openCraftMenu)
		
		{
			if(clicked == "")
			{

				GUI.Box(new Rect(left,top,Screen.width/2+left,Screen.height-10),"FORGERON",boxStyle);
				GUI.TextArea(new Rect(left+50,top,210,40),"Inventaire",proposStyle);
				GUI.TextArea(new Rect(Screen.width/2+left-50,top,210,40),"Crafting",proposStyle);
				//button
				GUI.DrawTexture(new Rect(50+left,105,100,100),Bois);
				_bois = GUI.Button(new Rect(200+left,150,50,50),bois.ToString());
				_c_bois = GUI.Button(new Rect((Screen.width/4+left)+ 300,150,50,50),c_bois.ToString());
				
				GUI.DrawTexture(new Rect(50+left,205,100,100),Metal);
				_metal = GUI.Button(new Rect(200+left,250,50,50),metal.ToString());
				_c_metal = GUI.Button(new Rect((Screen.width/4+left)+ 300,250,50,50),c_metal.ToString());
				
				GUI.DrawTexture(new Rect(50+left,305,100,100),Tissu);
				_tissu = GUI.Button(new Rect(200+left,350,50,50),tissu.ToString());
				_c_tissu = GUI.Button(new Rect((Screen.width/4+left)+ 300,350,50,50),c_tissu.ToString());
				
				GUI.DrawTexture(new Rect(50+left,405,100,100),Partition);
				_partition = GUI.Button(new Rect(200+left,450,50,50),partition.ToString());
				_c_partition = GUI.Button(new Rect((Screen.width/4+left)+ 300,450,50,50),c_partition.ToString());
				
				GUI.DrawTexture(new Rect(50+left,505,100,100),Guitar);
				_guitar = GUI.Button(new Rect(200+left,550,50,50),guitar.ToString());
				_c_guitar = GUI.Button(new Rect((Screen.width/4+left)+ 300,550,50,50),c_guitar.ToString());

				if(_next = GUI.Button (new Rect((Screen.width/4+left)+ 200,Screen.height/2-100,50,50),"->"))
				{
						clicked = "nextCraft";
						craftChoice += 1;
				}
			
					//if(!craftChoice){
				GUI.DrawTexture (new Rect((Screen.width/4+left),Screen.height/2-200,200,200),Corde);
				GUI.TextArea(new Rect((Screen.width/4+left),Screen.height/2,210,20),"Corde: bois x2, metal x1, tissu x1");
				GUI.TextArea(new Rect((Screen.width/4+left),Screen.height/2+25,210,40),msg);

				_combine = GUI.Button(new Rect((Screen.width/4+left),450,200,50),"Combine");
				_quitter = GUI.Button(new Rect((Screen.width/4+left),510,200,40),"Quitter");

			}

			else if(clicked == "nextCraft")
			{
			
				GUI.Box(new Rect(left,top,Screen.width/2+left,Screen.height-10),"FORGERON", boxStyle);
				GUI.TextArea(new Rect(left+50,top,210,40),"Inventaire",proposStyle);
				GUI.TextArea(new Rect(Screen.width/2+left-50,top,210,40),"Crafting",proposStyle);
					//button
					GUI.DrawTexture(new Rect(50+left,105,100,100),Bois);
					_bois = GUI.Button(new Rect(200+left,150,50,50),bois.ToString());
					_c_bois = GUI.Button(new Rect((Screen.width/4+left)+ 300,150,50,50),c_bois.ToString());
					
					GUI.DrawTexture(new Rect(50+left,205,100,100),Metal);
					_metal = GUI.Button(new Rect(200+left,250,50,50),metal.ToString());
					_c_metal = GUI.Button(new Rect((Screen.width/4+left)+ 300,250,50,50),c_metal.ToString());

					GUI.DrawTexture(new Rect(50+left,305,100,100),Tissu);
					_tissu = GUI.Button(new Rect(200+left,350,50,50),tissu.ToString());
					_c_tissu = GUI.Button(new Rect((Screen.width/4+left)+ 300,350,50,50),c_tissu.ToString());

					GUI.DrawTexture(new Rect(50+left,405,100,100),Partition);
					_partition = GUI.Button(new Rect(200+left,450,50,50),partition.ToString());
					_c_partition = GUI.Button(new Rect((Screen.width/4+left)+ 300,450,50,50),c_partition.ToString());

					GUI.DrawTexture(new Rect(50+left,505,100,100),Guitar);
					_guitar = GUI.Button(new Rect(200+left,550,50,50),guitar.ToString());
					_c_guitar = GUI.Button(new Rect((Screen.width/4+left)+ 300,550,50,50),c_guitar.ToString());

					if(_next = GUI.Button (new Rect((Screen.width/4+left)+ 200,Screen.height/2-100,50,50),"->"))
					{
						clicked = "";
						craftChoice -= 1;
					}

					GUI.DrawTexture (new Rect((Screen.width/4+left),Screen.height/2-200,200,200),Guitar);
					GUI.TextArea(new Rect((Screen.width/4+left),Screen.height/2,210,20),"Guitar: bois x4, guitar x2");
					GUI.TextArea(new Rect((Screen.width/4+left),Screen.height/2+25,210,40),msg);


						_combine = GUI.Button(new Rect((Screen.width/4+left),450,200,50),"Combine");
						_quitter = GUI.Button(new Rect((Screen.width/4+left),510,200,40),"Quitter");

			}




			}

		//Behavior button

		if(_bois){
			if(bois != 0){
				bois -= 1;
				c_bois += 1;
			}
		}
		if(_metal){
			if(metal != 0){
				metal -= 1;
				c_metal += 1;
			}
		}
		if(_tissu){
			if(tissu  != 0){
				tissu -= 1;
				c_tissu += 1;
			}
		}
		if(_partition){
			if(partition != 0){
				partition -= 1;
				c_partition += 1;
			}
		}
		if(_guitar){
			if(guitar != 0){
				guitar -= 1;
				c_guitar += 1;
			}
		}
		if(_c_bois){
			if(c_bois != 0){
				c_bois -= 1;
				bois += 1;
			}
		}
		if(_c_metal){
			if(c_metal != 0){
				c_metal -= 1;
				metal += 1;
			}
		}
		if(_c_tissu){
			if(c_tissu  != 0){
				c_tissu -= 1;
				tissu += 1;
			}
		}
		if(_c_partition){
			if(c_partition != 0){
				c_partition -= 1;
				partition += 1;
			}
		}
		if(_c_guitar){
			if(c_guitar != 0){
				c_guitar -= 1;
				guitar += 1;
			}
		}
		if(_combine){
			if(craftChoice == 1)
			{
				if(c_bois == 2 && c_metal == 1 && c_tissu == 1){
					msg = "Bravo, vous venez de construire une corde!";
					inventory.level+=1;
					combineDone = true;
					tBois=c_bois;
					c_bois -=2;
					tMetal=c_metal;
					c_metal-=1;
					tTissu=c_tissu;
					c_tissu-=1;
				}
					
				else{
					msg = "Manque de ressources!";
					combineDone = false;
				}
					
			}
			else{
				if(c_bois == 4 && c_guitar ==2){
					msg = "Bravo, vous venez de construire une corde!";
					inventory.level+=1;
					combineDone = true;
					tBois=c_bois;
					c_bois-=4;
					tGuitar=c_guitar;
					c_guitar-=2;

				}
				
				else{
					msg = "Manque de ressources!";
					combineDone = false;
				}
			}
		}
		if(_quitter){
			openCraftMenu=false;
			msg= "";
			miseajourInventaire();
			combineDone = false;
		}

	}
	private void miseajourInventaire()
	{
		Debug.Log ("function");
		if(combineDone){
			int fin = c_bois+c_metal+c_tissu+c_guitar+c_partition;
			for(int i=0;i<inventory.length-fin;i++)
			{
				switch(inventory.Inventory[i].Type){
					
				case 0: 
					if(tBois != 0){
						inventory.erase(i);
						tBois-=1;
					}
					break;
				case 1: 
					if(tMetal!=0){
						inventory.erase(i);
						tMetal -= 1;
					}
					break;
				case 2: 
					if(tTissu != 0){
						inventory.erase(i);
						tTissu -= 1;
					}
					break;
				case 3: 
					if(tPartition != 0){
						inventory.erase(i);
						tPartition -= 1;
					}
					break;
				case 4: 
					if(tGuitar != 0){
						inventory.erase(i);
						tGuitar -= 1;
					}
					break;
				}
			}
		}
		bois =0;
		metal =0;
		tissu =0;
		partition =0;
		guitar =0;

		c_bois =0;
		c_metal =0;
		c_tissu =0;
		c_partition =0;
		c_guitar =0;
		
	}
	void OnTriggerExit(Collider other)
	{
		if(other.name == "Personnage"){
			onCollision = false;
		}
	}
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey("i") && onCollision){

			openCraftMenu = true;
			onCollision = false;
			for(int i = 0; i< inventory.length; i++)
			{
				switch(inventory.Inventory[i].Type){

				case 0: bois+=1;break;
				case 1: metal+=1;break;
				case 2: tissu+=1;break;
				case 3: partition+=1;break;
				case 4: guitar+=1;break;
				
				}

			}

		}
	}
}
