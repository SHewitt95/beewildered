using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	bool introHivePlaced = false;
	GUIText[] introtext;
	int text = 0;
	int currentFrame = 0;

	// Use this for initialization
	void Start () {

		hideAllText ();
		GameManager.introPanel.transform.GetChild(text).gameObject.SetActive(true);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.INTRO) {

			/*
			if (!introHivePlaced && Input.GetMouseButtonDown(0)) {
				
				GameObject hive = GameObject.FindGameObjectWithTag ("Player");

				Vector3 newPosition = new Vector3 (Camera.main.transform.position.x, 
					Camera.main.transform.position.y, Camera.main.transform.position.z + 4.85f);
				
				hive.transform.position = newPosition;
				Camera.main.transform.DetachChildren ();
				introHivePlaced = true;
			}
			*/

			if (currentFrame % 3 == 0) {
				incrementText ();
			}

			currentFrame++;

		}
	
	}

	void hideAllText() {

		foreach (Transform child in GameManager.introPanel.transform) {
			//print ("Foreach loop: " + child);
			child.gameObject.SetActive (false);
		}

	}

	void incrementText() {
		if (Input.GetKey(KeyCode.Space)) {
			

			if (text >= GameManager.introPanel.transform.childCount) {
				
				GameManager.introPanel.SetActive (false);

			} else {

				GameManager.introPanel.transform.GetChild(text).gameObject.SetActive(false);
				GameManager.introPanel.transform.GetChild(++text).gameObject.SetActive(true);

			}


		}
	}

	public static void InitiateIntroState() {
		Debug.Log ("Intro!");
		GameManager.introPanel.gameObject.SetActive (true);
		//GameManager.canvas.
	}
}
