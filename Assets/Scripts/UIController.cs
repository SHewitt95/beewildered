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

	int text;

	// Use this for initialization
	void Start () {

		text = 1;
		howToPlay.gameObject.SetActive(false);
		collectPanel.gameObject.SetActive(false);
		seedsPanel.gameObject.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
		//print(GameManager.instance.GetCurrentState());
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
		//GameManager.instance.checkUserInput ("x");
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

	public void nextText() {

		if (Intro.introHivePlaced) {
			introPanel.transform.GetChild(text).gameObject.SetActive(false);
			introPanel.transform.GetChild(++text).gameObject.SetActive(true);
		}


	}
}
