﻿using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour {

	//Flowers
	public GameObject dandelion;

	//Trees
	public GameObject appleTree;

	//Bushes
	public GameObject blueberries;


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

				Instantiate (dandelion, player.transform.position, player.transform.rotation);
				// Dandelion value
				GameManager.gridValues [SnapMovement.staticCurrentPos] = Dandelion.getNectarValue();
				GameManager.grid [SnapMovement.staticCurrentPos] = 2;



				GameManager.instance.resetState ();
				//Bank.subtractNectar (10);
			}

		}
	
	}

	public static void InitiateBuildState() {
		Debug.Log ("Build!");
		//GameManager.buildPanel.gameObject.SetActive (true);
		//GameManager.canvas.
	}
}
