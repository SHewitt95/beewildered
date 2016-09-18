using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.COLLECT) {
			Debug.Log ("Collect!");
		}
	
	}
}
