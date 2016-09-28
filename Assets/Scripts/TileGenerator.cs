using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour {

	public GameObject tile;

	// Use this for initialization
	void Start () {

		int row;
		int column;
		int max = 8;

		int xPos = 0;
		int yPos = 0;
		int zPos = 0;

		int tileSize = 15;

		for (row = 0; row < max; row++) { // Make rows

			for (column = 0; column < max; column++) { // Make columns
				GameObject newTile = (GameObject) Instantiate(tile, new Vector3(xPos, yPos, zPos), Quaternion.identity);
				zPos += tileSize;

				/*
				if (Random.value < 0.25) {
					newTile.GetComponent<Renderer>().material.color = Color.blue;
				}*/
			}

			xPos += tileSize;
			zPos = 0;

		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
