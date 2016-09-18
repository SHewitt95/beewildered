using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	bool introHivePlaced = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.INTRO) {

			Debug.Log ("Intro...");

			if (!introHivePlaced && Input.GetMouseButtonDown(0)) {
				Debug.Log ("Attempting to place...");
				GameObject hive = GameObject.FindGameObjectWithTag ("Player");
				Vector3 newPosition = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 4.85f);
				hive.transform.position = newPosition;
				Camera.main.transform.DetachChildren ();
				introHivePlaced = true;
			}

		}
	
	}

	public static void InitiateIntroState() {
		Debug.Log ("Intro!");
		GameManager.introPanel.gameObject.SetActive (true);
		//GameManager.canvas.
	}
}
