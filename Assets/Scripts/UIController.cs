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


	// Use this for initialization
	void Start () {

		howToPlay.gameObject.SetActive(false);
		collectPanel.gameObject.SetActive(false);
		seedsPanel.gameObject.SetActive(false);
		bankPanel.gameObject.SetActive(false);
		buildPanel.gameObject.SetActive(false);
		buildSwarmPanel.gameObject.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		//print(GameManager.instance.GetCurrentState());
		if (GameManager.instance.GetCurrentState () == GameManager.GameStates.CAMERA) {
			bankPanel.gameObject.SetActive(true);
		}
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
		hivePanel.gameObject.SetActive(false);
	}

	public void closeNeutral() {
		neutralPanel.gameObject.SetActive (false);
	}

	public void openCollectPanel() {
		collectPanel.gameObject.SetActive (true);
	}

	public void StartButton() {
		openingMenu.gameObject.SetActive (false);
		GameManager.introPanel.SetActive (true);
		GameManager.instance.checkUserInput ("y");
	}

	public void howToPlayButton() {
		openingMenu.gameObject.SetActive (false);
		howToPlay.gameObject.SetActive(true);
	}

	public void backFromHowToPlay() {
		openingMenu.gameObject.SetActive (true);
		howToPlay.gameObject.SetActive(false);
	}

	public void sendCollectInput() {
		GameManager.instance.checkUserInput ("v");
		collectPanel.gameObject.SetActive (false);

		//print (Input.GetButtonDown("Swarm 1"));
	}

	public void sendBuildInput() {
		GameManager.instance.checkUserInput ("b");
		//collectPanel.gameObject.SetActive (false);

		//print (Input.GetButtonDown("Swarm 1"));
	}

	public void nextText() {

		//if (Intro.introHivePlaced) {
			introPanel.transform.GetChild(Intro.text).gameObject.SetActive(false);
			introPanel.transform.GetChild(++Intro.text).gameObject.SetActive(true);
		//}


	}
}
