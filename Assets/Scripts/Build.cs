using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Build : MonoBehaviour {

	//Flowers
	public GameObject dandelion;
	public GameObject sunflowers;

	//Trees
	public GameObject appleTree;
	public GameObject orangeTree;

	//Bushes
	public GameObject blueberries;

	GameObject player;

	public static string currentBuildObject;

	public static List<Object> allObjects = new List<Object> ();

	public UIController uicontroller;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		//allObjects = new List<Object> ();

		for (int i = 0; i < GameManager.grid.Length; i++) {
			allObjects.Add (null);
		}
				
	}
	
	// Update is called once per frame
	void Update () {
		placeObject ();
		/*
		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.BUILD) {
			//InitiateBuildState ();
			Debug.Log ("Build!");

			if (Input.GetKeyDown(KeyCode.Return) &&
				GameManager.grid[SnapMovement.staticCurrentPos] == 0) {

				Vector3 pos = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

				Instantiate (dandelion, pos, player.transform.rotation);

				// Dandelion value
				GameManager.gridValues [SnapMovement.staticCurrentPos] = Dandelion.getNectarValue();
				GameManager.grid [SnapMovement.staticCurrentPos] = 2;

				GameManager.instance.resetState ();
				//Bank.subtractNectar (10);
			}

		}
	*/
	}

	public void placeObject() {
		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.BUILD) {
			//InitiateBuildState ();
			Debug.Log ("Build!");

			if (Input.GetKeyDown(KeyCode.Return) &&
				GameManager.grid[SnapMovement.staticCurrentPos] == 0) {

				uicontroller.hidePressEnterToBuild ();

				switch(currentBuildObject) {

				case "dandelion":
					if (Bank.subtractHoney(Dandelion.getCost())) {
						Vector3 pos = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

						GameManager.allGameObjects[SnapMovement.staticCurrentPos] = (GameObject) Instantiate (dandelion, pos, player.transform.rotation);

						// Dandelion value
						GameManager.gridValues [SnapMovement.staticCurrentPos] = Dandelion.getNectarValue();
						GameManager.grid [SnapMovement.staticCurrentPos] = 2;

						//print (GameManager.allGameObjects[SnapMovement.staticCurrentPos].GetComponent<Dandelion>().collectingPollen);
					}
					break;

				case "apple tree":
					
					//Vector3 originalSize = aptree.transform.localScale;
					//aptree.transform.localScale = new Vector3 (0, 0, 0);
					//print ("Apple Tree cost: " + aptree.getCost ());

					if (Bank.subtractHoney (AppleTree.getCost ())) {
						//Vector3 pos1 = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

						//AppleTree aptree = (AppleTree)Instantiate (appleTree, pos1, player.transform.rotation);
						//aptree.transform.localScale = originalSize;

						Vector3 pos1 = new Vector3 (player.transform.position.x, 0, player.transform.position.z);
						GameManager.allGameObjects[SnapMovement.staticCurrentPos] = (GameObject)Instantiate (appleTree, pos1, player.transform.rotation);

						// Dandelion value
						GameManager.gridValues [SnapMovement.staticCurrentPos] = AppleTree.getNectarValue ();
						GameManager.grid [SnapMovement.staticCurrentPos] = 2;

						//allObjects [SnapMovement.staticCurrentPos] = aptree.gameObject.GetComponent<AppleTree>();

						//print ("test: " + allObjects [SnapMovement.staticCurrentPos].name);
					}
					break;

				case "orange tree":
					if (Bank.subtractHoney(OrangeTree.getCost())) {
						Vector3 pos2 = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

						GameManager.allGameObjects[SnapMovement.staticCurrentPos] = (GameObject)Instantiate (orangeTree, pos2, player.transform.rotation);

						// Dandelion value
						GameManager.gridValues [SnapMovement.staticCurrentPos] = OrangeTree.getNectarValue();
						GameManager.grid [SnapMovement.staticCurrentPos] = 2;
					}
					break;

				case "sunflowers":
					if (Bank.subtractHoney(Sunflowers.getCost())) {
						Vector3 pos3 = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

						GameManager.allGameObjects[SnapMovement.staticCurrentPos] = (GameObject)Instantiate (sunflowers, pos3, player.transform.rotation);

						// Dandelion value
						GameManager.gridValues [SnapMovement.staticCurrentPos] = Sunflowers.getNectarValue();
						GameManager.grid [SnapMovement.staticCurrentPos] = 2;
					}
					break;
				}

				GameManager.numOfPlants++;


				SnapMovement.restoreModel ();
				GameManager.instance.resetState ();
				uicontroller.openNeutralPanel ();
				//Bank.subtractNectar (10);
			}

		}
	}

	public static void InitiateBuildState() {
		Debug.Log ("Build!");
		//GameManager.buildPanel.gameObject.SetActive (true);
		//GameManager.canvas.
	}

	public void spawnBuildItem(string item) {

	}
}
