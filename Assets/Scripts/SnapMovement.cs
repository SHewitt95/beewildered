using UnityEngine;
using System.Collections;

public class SnapMovement : MonoBehaviour {

	int tilePosition;
	float speed = 80.0f;

	Vector3 pos;                                // For movement

	private static int currentX;					// Current x position
	private static int currentY;					// Current y position
	public int currentPos;

	public static int staticCurrentPos;

	public float leftBound;
	public float rightBound;
	public float topBound;
	public float bottomBound;
	public int tileSize;

	public static GameObject player;

	public GameObject dandelion;
	public GameObject appleTree;
	public GameObject orangeTree;
	public GameObject sunFlower;

	private GameObject currentModel;

	static GameObject theModel;

	// Use this for initialization
	void Start () {

		transform.position = new Vector3 (153, 3, 150);
		currentPos = 210;

		tileSize = 20;

		pos = transform.position;
		bottomBound = 0;
		leftBound = bottomBound + 3;
		topBound = 285;
		rightBound = topBound + 3;

		player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {


		if (GameManager.instance.GetCurrentState() != GameManager.GameStates.START) {
			MoveDiscrete ();
		}

	
	}
		

	void MoveDiscrete() {

		/*
		 * Grid-style movement: http://answers.unity3d.com/answers/892128/view.html
		 * Added features: 
		 * ...Preventing movement when Grid bounds are reached.
		 * ...Incrementing the player's X and Y coordinates accordingly.
		 * ...Abstracting the code to a separate method.
		 */

		if(Input.GetKey(KeyCode.A) && transform.position == pos) {        // Left
			if (pos.x > leftBound) {
				pos += Vector3.left * 15;
				currentPos -= tileSize;
			}

		}
		if(Input.GetKey(KeyCode.D) && transform.position == pos) {        // Right
			if (pos.x != rightBound) {
				pos += Vector3.right * 15;
				currentPos += tileSize;
			}
				
		}
		if(Input.GetKey(KeyCode.W) && transform.position == pos) {        // Up
			if (pos.z < topBound) {
				pos += Vector3.forward * 15; 
				currentPos += 1;
			}
				
		}
		if(Input.GetKey(KeyCode.S) && transform.position == pos) {        // Down
			if (pos.z != bottomBound) {
				pos += Vector3.back * 15;
				currentPos -= 1;
			}
				
		}

		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
		staticCurrentPos = currentPos;
		//Debug.Log (currentPos);

	}

	public void changeCurrentModel(string model) {

		Vector3 pos = new Vector3 (transform.position.x, 3, 150);
		Build.currentBuildObject = model;

		switch (model) {
		case "dandelion":
			theModel = (GameObject) Instantiate (dandelion, player.transform.position, player.transform.rotation);
			//DestroyImmediate (this.gameObject, true);
			gameObject.transform.localScale = new Vector3(0,0,0);
			//currentModel = theModel;
			break;

		case "apple tree":
			theModel = (GameObject) Instantiate (appleTree, player.transform.position, player.transform.rotation);
			//DestroyImmediate (this.gameObject, true);
			gameObject.transform.localScale = new Vector3(0,0,0);
			//currentModel = theModel;
			break;

		case "orange tree":
			theModel = (GameObject) Instantiate (orangeTree, player.transform.position, player.transform.rotation);
			//DestroyImmediate (this.gameObject, true);
			gameObject.transform.localScale = new Vector3(0,0,0);
			//currentModel = theModel;
			break;

		case "sunflowers":
			theModel = (GameObject) Instantiate (sunFlower, player.transform.position, player.transform.rotation);
			//DestroyImmediate (this.gameObject, true);
			gameObject.transform.localScale = new Vector3(0,0,0);
			//currentModel = theModel;
			break;
		}
	}

	public static void restoreModel() {
		Destroy (theModel);
		player.gameObject.transform.localScale = new Vector3(1,1,1);
	}
}
