using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
	
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

				switch(currentBuildObject) {
				case "dandelion":
					if (Bank.subtractHoney(Dandelion.getCost())) {
						Vector3 pos = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

						Instantiate (dandelion, pos, player.transform.rotation);

						// Dandelion value
						GameManager.gridValues [SnapMovement.staticCurrentPos] = Dandelion.getNectarValue();
						GameManager.grid [SnapMovement.staticCurrentPos] = 2;
					}
					break;

				case "apple tree":
					if (Bank.subtractHoney(AppleTree.getCost())) {
						Vector3 pos1 = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

						Instantiate (appleTree, pos1, player.transform.rotation);

						// Dandelion value
						GameManager.gridValues [SnapMovement.staticCurrentPos] = AppleTree.getNectarValue();
						GameManager.grid [SnapMovement.staticCurrentPos] = 2;
					}
					break;

				case "orange tree":
					if (Bank.subtractHoney(OrangeTree.getCost())) {
						Vector3 pos1 = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

						Instantiate (orangeTree, pos1, player.transform.rotation);

						// Dandelion value
						GameManager.gridValues [SnapMovement.staticCurrentPos] = AppleTree.getNectarValue();
						GameManager.grid [SnapMovement.staticCurrentPos] = 2;
					}
					break;

				case "sunflowers":
					if (Bank.subtractHoney(Sunflowers.getCost())) {
						Vector3 pos1 = new Vector3 (player.transform.position.x, 0, player.transform.position.z);

						Instantiate (sunflowers, pos1, player.transform.rotation);

						// Dandelion value
						GameManager.gridValues [SnapMovement.staticCurrentPos] = AppleTree.getNectarValue();
						GameManager.grid [SnapMovement.staticCurrentPos] = 2;
					}
					break;
				}


				SnapMovement.restoreModel ();
				GameManager.instance.resetState ();
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
