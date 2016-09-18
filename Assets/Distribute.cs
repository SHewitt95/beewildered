using UnityEngine;
using System.Collections;

public class Distribute : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.DISTRIBUTE) {
			Debug.Log ("Distribute!");
		}
	
	}
}
