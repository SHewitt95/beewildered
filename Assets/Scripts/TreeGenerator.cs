﻿using UnityEngine;
using System.Collections;

public class TreeGenerator : MonoBehaviour {

	public GameObject tree;
	public GameObject gentree1;
	public GameObject gentree2;
	public GameObject pinetree;
	public GameObject boulder1;
	public GameObject boulder2;

	int frame;

	//public int[] treePositions = new int[64];

	// Use this for initialization
	void Start () {
		
		int row;
		int column;

		int xPos = 0;
		int yPos = 0;
		int zPos = 0;
		int max = 20;


		int gridPos = 0;

		int tileSize = 15;

		for (row = 0; row < max; row++) { // Make rows

			for (column = 0; column < max; column++) { // Make columns

				// Randomly spawn a gameobject
				if (Random.value < 0.2) {

					float myValue = Random.value;

					if (myValue <= 0.15) {
						GameObject newObj = (GameObject) Instantiate(pinetree, new Vector3(xPos + 5, yPos, zPos + 5), Quaternion.identity);
						//GameObject newObj = (GameObject) Instantiate(pinetree, new Vector3(xPos, yPos, zPos), Quaternion.identity);
						float scaleValue = Random.Range (80, 170);
						newObj.transform.localScale = new Vector3 (scaleValue, scaleValue, scaleValue);
						GameManager.grid [gridPos] = 1;

					} else if (myValue > 0.15 && myValue <= 0.4) {
						GameObject newObj = (GameObject) Instantiate(gentree1, new Vector3(xPos + 5, yPos + 4, zPos + 5), Quaternion.identity);
						//GameObject newObj = (GameObject) Instantiate(gentree1, new Vector3(xPos, yPos + 4, zPos), Quaternion.identity);
						float scaleValue = Random.Range (80, 170);
						newObj.transform.localScale = new Vector3 (scaleValue, scaleValue, scaleValue);
						GameManager.grid [gridPos] = 1;

					} else if (myValue > 0.4 && myValue <= 0.6) {
						GameObject newObj = (GameObject) Instantiate(gentree2, new Vector3(xPos + 5, yPos - 1, zPos + 5), Quaternion.identity);
						//GameObject newObj = (GameObject) Instantiate(gentree2, new Vector3(xPos, yPos - 1, zPos), Quaternion.identity);
						float scaleValue = Random.Range (80, 170);
						newObj.transform.localScale = new Vector3 (scaleValue, scaleValue, scaleValue);
						GameManager.grid [gridPos] = 1;

					} else if (myValue > 0.6 && myValue <= 0.8) {
						GameObject newObj = (GameObject) Instantiate(boulder1, new Vector3(xPos + 5, yPos, zPos + 5), Quaternion.identity);
						//GameObject newObj = (GameObject) Instantiate(boulder1, new Vector3(xPos, yPos, zPos), Quaternion.identity);
						float scaleValue = Random.Range (30, 100);
						newObj.transform.localScale = new Vector3 (scaleValue, scaleValue, scaleValue);
						GameManager.grid [gridPos] = 3;

					} else if (myValue > 0.8 && myValue <= 0.99) {
						GameObject newObj = (GameObject) Instantiate(boulder2, new Vector3(xPos + 5, yPos, zPos + 5), Quaternion.identity);
						//GameObject newObj = (GameObject) Instantiate(boulder2, new Vector3(xPos, yPos, zPos), Quaternion.identity);
						float scaleValue = Random.Range (30, 100);
						newObj.transform.localScale = new Vector3 (scaleValue, scaleValue, scaleValue);
						GameManager.grid [gridPos] = 3;
					}
						
				}


				zPos += tileSize;
				gridPos++;
			}

			xPos += tileSize;
			zPos = 0;
		}



		//printGrid ();
	}
	
	// Update is called once per frame
	void Update () {



		if (frame < 1) {
			
		}

		frame++;
	
	}

	void printGrid() {
		for (int i = 0; i < GameManager.grid.Length; i++) {

			print ("Index " + i + ": " + GameManager.grid[i]);

		}
	}

}
