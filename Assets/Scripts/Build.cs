using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*if (GameManager.instance.GetCurrentState() == GameManager.GameStates.BUILD) {
			InitiateBuildState ();
		}*/
	
	}

	public static void InitiateBuildState() {
		Debug.Log ("Build!");
		GameManager.buildPanel.gameObject.SetActive (true);
		//GameManager.canvas.
	}
}
