using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public static bool introHivePlaced = false;
	GUIText[] introtext;
	public static int text = 0;
	int currentFrame = 0;

	public GameObject hive;
	public GameObject player;

	// Use this for initialization
	void Start () {

		hideAllText ();
		GameManager.introPanel.transform.GetChild(text).gameObject.SetActive(true);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.INTRO) {

			//GameManager.introPanel.SetActive (true);

			// Spawn Hive
			if (!introHivePlaced &&
				Input.GetKeyDown(KeyCode.Return) &&
				GameManager.grid[SnapMovement.staticCurrentPos] == 1) {

				Vector3 pos = new Vector3(player.transform.position.x - 2, player.transform.position.y, player.transform.position.z + 2);

				Instantiate (hive, pos, player.transform.rotation);
				introHivePlaced = true;

				GameManager.introPanel.transform.GetChild(text).gameObject.SetActive(false);
				GameManager.introPanel.transform.GetChild(++text).gameObject.SetActive(true);

				//GameManager.instance.checkUserInput ("x");
				
			}

		}
	
	}

	public static void HivePlaced () {
		introHivePlaced = true;
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
