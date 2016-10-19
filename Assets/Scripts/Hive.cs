using UnityEngine;
using System.Collections;

public class Hive : MonoBehaviour {

	public GameObject hivePanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void InitiateHiveState() {
		Debug.Log ("Hive!");
		GameManager.hivePanel.gameObject.SetActive (true);
		//GameManager.canvas.
	}
}
