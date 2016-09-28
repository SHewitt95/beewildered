using UnityEngine;
using System.Collections;

public class SnapMovement : MonoBehaviour {

	int tilePosition;
	float speed = 60.0f;

	Vector3 pos;                                // For movement

	private static int currentX;					// Current x position
	private static int currentY;					// Current y position
	public int currentPos;

	public float leftBound;
	public float rightBound;
	public float topBound;
	public float bottomBound;

	// Use this for initialization
	void Start () {

		pos = transform.position;
		bottomBound = 0;
		leftBound = bottomBound + 3;
		topBound = 225;
		rightBound = topBound + 3;

	}
	
	// Update is called once per frame
	void Update () {

		/*
		if (((Mathf.Round(Camera.main.gameObject.transform.position.x) % 15) == 0)
			&& ((Mathf.Round(Camera.main.gameObject.transform.position.z) % 15) == 0)) {

			gameObject.transform.position = new Vector3 (Mathf.Round(Camera.main.gameObject.transform.position.x), 
				3.0f, 
				Mathf.Round(Camera.main.gameObject.transform.position.z) + 25);
			
		}
		*/
		MoveDiscrete ();
	
	}
		

	void moveX() {

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		//transform.position += move * speed * Time.deltaTime;

	}

	void moveZ() {

		Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical"));
		//transform.position += move * speed * Time.deltaTime;

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
				currentPos -= 8;
			}

		}
		if(Input.GetKey(KeyCode.D) && transform.position == pos) {        // Right
			if (pos.x != rightBound) {
				pos += Vector3.right * 15;
				currentPos += 8;
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
		//Debug.Log (currentPos);

	}
}
