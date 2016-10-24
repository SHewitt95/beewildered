using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject openingMenu;
	public GameObject howToPlay;
	public GameObject collectPanel;
	public GameObject neutralPanel;

	// Use this for initialization
	void Start () {

		howToPlay.gameObject.SetActive(false);
		collectPanel.gameObject.SetActive(false);

	
	}
	
	// Update is called once per frame
	void Update () {
		//print(GameManager.instance.GetCurrentState());
	}

	public void closeNeutral() {
		neutralPanel.gameObject.SetActive (false);
	}

	public void openCollectPanel() {
		collectPanel.gameObject.SetActive (true);
	}

	public void StartButton() {
		openingMenu.gameObject.SetActive (false);
		GameManager.instance.checkUserInput ("x");
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
	}
}
