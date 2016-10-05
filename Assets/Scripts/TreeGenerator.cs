using UnityEngine;
using System.Collections;

public class TreeGenerator : MonoBehaviour {

	public GameObject tree;
	int frame;

	//public int[] treePositions = new int[64];

	// Use this for initialization
	void Start () {
		frame = 0;
	}
	
	// Update is called once per frame
	void Update () {



		if (frame < 1) {
			int row;
			int column;

			int xPos = 0;
			int yPos = 0;
			int zPos = 0;
			int max = 15;


			int gridPos = 0;

			int tileSize = 15;

			for (row = 0; row < max; row++) { // Make rows

				for (column = 0; column < max; column++) { // Make columns

					if (Random.value < 0.35) {
						//print (gridPos);
						/*if (gridPos >= GameManager.grid.Length) {
							break;
						}*/
						GameObject newTree = (GameObject) Instantiate(tree, new Vector3(xPos + 5, yPos, zPos + 5), Quaternion.identity);
						GameManager.grid [gridPos] = 1;
					}


					zPos += tileSize;
					gridPos++;
				}

				xPos += tileSize;
				zPos = 0;
			}



			printGrid ();
		}

		frame++;
	
	}

	void printGrid() {
		for (int i = 0; i < GameManager.grid.Length; i++) {

			print ("Index " + i + ": " + GameManager.grid[i]);

		}
	}

}
