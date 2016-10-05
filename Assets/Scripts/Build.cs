using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour {

	public GameObject flower1;
	GameObject player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.BUILD) {
			//InitiateBuildState ();
			Debug.Log ("Build!");

			if (Input.GetKeyDown(KeyCode.Return) &&
				GameManager.grid[SnapMovement.staticCurrentPos] == 0) {

				Instantiate (flower1, player.transform.position, player.transform.rotation);
				GameManager.grid [SnapMovement.staticCurrentPos] = 2;
			}

		}
	
	}

	public static void InitiateBuildState() {
		Debug.Log ("Build!");
		GameManager.buildPanel.gameObject.SetActive (true);
		//GameManager.canvas.
	}
}
