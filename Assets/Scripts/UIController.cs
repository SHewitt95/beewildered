using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject openingMenu;
	public GameObject howToPlay;
	public GameObject collectPanel;
	public GameObject neutralPanel;
	public GameObject introPanel;
	public GameObject seedsPanel;
	public GameObject hivePanel;
	public GameObject bankPanel;
	public GameObject buildPanel;
	public GameObject buildSwarmPanel;
	public GameObject selectedSwarmPanel;
	public GameObject collectSwarmPanel;

	public Text pressEnterToBuild;
	public Text pressEnterToCollect;
	public Text collectCounter;
	public Text incorrectCollect;
	public Text upgradeText;

	public Text swarmLevel;
	public Text swarmPatchLimit;
	public Text swarmCurrentPatches;
	public Text swarmSpeed;

	public Button build;
	public Button collect;
	public Button hiveButton;
	public Button nurse;

	public SwarmKeeper swarmkeeper;

	Button collectButton;


	GameObject hive;
	GameObject player;

	void Awake () {
		//neutralPanel = GameObject.FindGameObjectWithTag ("Neutral Panel");
	}

	// Use this for initialization
	void Start () {


		//neutralPanel = GameObject.FindGameObjectWithTag ("Neutral Panel");

		pressEnterToBuild.enabled = false;
		pressEnterToCollect.enabled = false;
		collectCounter.enabled = false;
		incorrectCollect.enabled = false;
		upgradeText.enabled = false;

		swarmLevel.enabled = false;
		swarmPatchLimit.enabled = false;
		swarmCurrentPatches.enabled = false;
		swarmSpeed.enabled = false;


		howToPlay.gameObject.SetActive(false);
		collectPanel.gameObject.SetActive(false);
		seedsPanel.gameObject.SetActive(false);
		bankPanel.gameObject.SetActive(false);
		buildPanel.gameObject.SetActive(false);
		buildSwarmPanel.gameObject.SetActive (false);
		selectedSwarmPanel.gameObject.SetActive (false);
		collectSwarmPanel.gameObject.SetActive (false);

		foreach (Transform obj in collectSwarmPanel.transform) {
			print (obj.name);
		}

		hidePressEnterToBuild ();
		hidePressEnterToCollect ();

	}
	
	// Update is called once per frame
	void Update () {
		//print(GameManager.instance.GetCurrentState());
		if (GameManager.instance.GetCurrentState () == GameManager.GameStates.CAMERA) {
			bankPanel.gameObject.SetActive(true);
		}


		if (GameManager.numOfPlants == 0) {
			//print(GameObject.FindGameObjectWithTag ("Collect Button").GetComponent<Button>());
			//GameObject.FindGameObjectWithTag ();
		} else {
			//collectButton = GameObject.Find ("Collect Button").SetActive (true);
		}

	}

	public void openSwarmPanel() {
		collectSwarmPanel.gameObject.SetActive (true);
	}

	public void closeSwarmPanel() {
		collectSwarmPanel.gameObject.SetActive (false);
	}

	public void showSwarmStats() {
		
		Swarm currentSwarm = swarmkeeper.getSelectedSwarm ();

		swarmLevel.enabled = true;
		swarmPatchLimit.enabled = true;
		swarmCurrentPatches.enabled = true;
		swarmSpeed.enabled = true;

		swarmLevel.text = "Level: " + currentSwarm.level;
		swarmPatchLimit.text = "Max Number of Plants: " + currentSwarm.patchLimit;
		swarmCurrentPatches.text = "# of Plants Currently Visiting: " + currentSwarm.getPathLocations().Count;
		swarmSpeed.text = "Speed: " + currentSwarm.agent.speed;

	}

	public void showPressEnterToCollect() {

		if (GameManager.numOfPlants > 0) {
			pressEnterToCollect.enabled = true;
			pressEnterToCollect.text = "Press \"Enter\" on your plants to have a Swarm collect from it.";
		} else {
			incorrectCollect.enabled = true;
			incorrectCollect.text = "You need to Build Plants before you Collect!";

			StartCoroutine (hideIncorrectCollectText());
		}

	}

	IEnumerator hideIncorrectCollectText() {
		yield return new WaitForSeconds (3f);
		incorrectCollect.enabled = false;

	}

	public void showUpgradeNotice() {
		upgradeText.enabled = true;
		upgradeText.text = "Your Swarm has been upgraded!";
		StartCoroutine (hideUpgradeNotice());
	}

	public void showUpgradeFail() {
		upgradeText.enabled = true;
		upgradeText.text = "You need more Honey!";
		StartCoroutine (hideUpgradeNotice());
	}

	IEnumerator hideUpgradeNotice() {
		yield return new WaitForSeconds (3f);
		upgradeText.enabled = false;
	}

	public void hidePressEnterToCollect() {
		pressEnterToCollect.enabled = false;
	}

	public void showCollectCount(int i) {
		collectCounter.enabled = true;
		collectCounter.text = "Plants left to pick: " + i;
	}

	public void hideCollectCount() {
		collectCounter.enabled = false;
		collectCounter.text = "";
	}

	public void hidePressEnterToBuild() {
		pressEnterToBuild.enabled = false;
	}

	public void showPressEnterToBuild() {
		pressEnterToBuild.enabled = true;
		pressEnterToBuild.text = "Press \"Enter\" to Build when the Plant glows Green.";
	}

	public void openSelectedSwarmPanel() {
		selectedSwarmPanel.gameObject.SetActive (true);
		showSwarmStats ();
	}

	public void closeSelectedSwarmPanel() {
		selectedSwarmPanel.gameObject.SetActive (false);
		swarmLevel.enabled = false;
		swarmPatchLimit.enabled = false;
		swarmCurrentPatches.enabled = false;
		swarmSpeed.enabled = false;
	}
		
	public void openBuildSwarmPanel() {
		buildSwarmPanel.gameObject.SetActive (true);
	}

	public void closeBuildSwarmPanel() {
		buildSwarmPanel.gameObject.SetActive (false);
	}

	public void openBuildPanel() {
		buildPanel.gameObject.SetActive(true);
		neutralPanel.gameObject.SetActive (false);
	}

	public void closeBuildPanel() {
		buildPanel.gameObject.SetActive(false);
	}

	public void openSeedsPanel () {
		seedsPanel.gameObject.SetActive(true);
	}

	public void closeSeedsPanel () {
		seedsPanel.gameObject.SetActive(false);
	}

	public void closeHivePanel() {
		hivePanel.gameObject.SetActive (false);
		for (int i = 0; i < hivePanel.transform.childCount; i++) {
			hivePanel.transform.GetChild (i).gameObject.SetActive (false);
		}
	}

	public void openHivePanel() {
		hivePanel.gameObject.SetActive (true);
		for (int i = 0; i < hivePanel.transform.childCount; i++) {
			hivePanel.transform.GetChild (i).gameObject.SetActive (true);
		}
	}

	public void openNeutralPanel() {
		neutralPanel.gameObject.SetActive (true);
		//GameManager.instance.checkUserInput ("x");
		//print ("Neutral ON!");
		/*build.gameObject.SetActive (true);
		collect.gameObject.SetActive (true);
		nurse.gameObject.SetActive (true);
		hiveButton.gameObject.SetActive (true);*/

		for (int i = 0; i < neutralPanel.transform.childCount; i++) {
			neutralPanel.transform.GetChild (i).gameObject.SetActive (true);
		}
	}

	public void sendNeutralInput () {
		GameManager.instance.checkUserInput ("x");
	}

	public void closeNeutral() {
		//neutralPanel.gameObject.SetActive (false);
		//bankPanel.gameObject.SetActive (false);
		//build.enabled = false;
		//collect.enabled = false;
		//hiveButton.enabled = false;
		//nurse.enabled = false;

		for (int i = 0; i < neutralPanel.transform.childCount; i++) {
			neutralPanel.transform.GetChild (i).gameObject.SetActive (false);
		}

		/*
		build.gameObject.SetActive (false);
		collect.gameObject.SetActive (false);
		nurse.gameObject.SetActive (false);
		hiveButton.gameObject.SetActive (false);
		*/

	}

	public void openBankPanel() {
		for (int i = 0; i < bankPanel.transform.childCount; i++) {
			bankPanel.transform.GetChild (i).gameObject.SetActive (true);
		}
	}

	public void closeBankPanel() {
		for (int i = 0; i < bankPanel.transform.childCount; i++) {
			bankPanel.transform.GetChild (i).gameObject.SetActive (false);
		}
	}

	void hideNeutralButtons() {
		foreach (Transform child in GameManager.neutralPanel.transform) {
			//print ("Foreach loop: " + child);
			child.gameObject.SetActive (false);
		}
	}

	public void closeIntroPanel() {
		introPanel.gameObject.SetActive (false);
	}

	public void openCollectPanel() {
		collectPanel.gameObject.SetActive (true);
	}

	public void StartButton() {
		openingMenu.gameObject.SetActive (false);
		GameManager.introPanel.SetActive (true);
		GameManager.instance.checkUserInput ("y");

		//GameManager.instance.checkUserInput ("v");
	}

	public void howToPlayButton() {
		//openingMenu.gameObject.SetActive (false);
		howToPlay.gameObject.SetActive(true);
	}

	public void backFromHowToPlay() {
		//openingMenu.gameObject.SetActive (true);
		howToPlay.gameObject.SetActive(false);
	}

	public void sendCollectInput() {

		if (GameManager.numOfPlants > 0) {
			GameManager.instance.checkUserInput ("v");
		}

		selectedSwarmPanel.gameObject.SetActive (false);

		//print (Input.GetButtonDown("Swarm 1"));
	}

	public void sendBuildInput() {
		GameManager.instance.checkUserInput ("b");
		//collectPanel.gameObject.SetActive (false);

		//print (Input.GetButtonDown("Swarm 1"));
	}

	public void sendCameraInput() {
		GameManager.instance.checkUserInput ("x");
	}

	public void nextText() {

		//if (Intro.introHivePlaced) {
			introPanel.transform.GetChild(Intro.text).gameObject.SetActive(false);
			introPanel.transform.GetChild(++Intro.text).gameObject.SetActive(true);
		//}


	}

	public void teleportToHive() {
		hive = GameObject.FindGameObjectWithTag ("Hive");
		player = GameObject.FindGameObjectWithTag ("Player");

		Vector3 pos = hive.gameObject.transform.position;

		player.gameObject.transform.position = pos;
	}
}
