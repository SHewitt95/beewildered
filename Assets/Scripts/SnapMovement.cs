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

	// Use this for initialization
	void Start () {

		pos = transform.position;
		bottomBound = 0;
		leftBound = bottomBound + 3;
		topBound = 285;
		rightBound = topBound + 3;

	}
	
	// Update is called once per frame
	void Update () {


		if (GameManager.instance.GetCurrentState() != GameManager.GameStates.INTRO) {
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
				currentPos -= 15;
			}

		}
		if(Input.GetKey(KeyCode.D) && transform.position == pos) {        // Right
			if (pos.x != rightBound) {
				pos += Vector3.right * 15;
				currentPos += 15;
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
}
