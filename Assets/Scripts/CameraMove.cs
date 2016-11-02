using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	Vector3 pos;                                // For movement
	float speed = 30.0f;                         // Speed of movement

	public float leftBound = 0;
	public float rightBound;
	public float upperBound;
	public float lowerBound = 0;

	public float xBound;
	public float zBound;

	// Use this for initialization
	void Start () {
		//Debug.Log ("Test");
	}
	
	// Update is called once per frame
	void Update () {

		switch (GameManager.instance.GetCurrentState()) {
			case GameManager.GameStates.CAMERA:
				//MoveContinuous();
				//TurnCamera ();
				showNeutralControls();
				moveWithObject();
				break;

		case GameManager.GameStates.COLLECT:
			    //moveToCollectView ();
				showNeutralControls();
				moveWithObject();
				break;

		case GameManager.GameStates.INTRO:
			//showNeutralControls();
			moveWithObject();
			break;

			default:
				moveWithObject();
				break;
		}

		//moveWithObject ();
			
	}

	void moveToCollectView() {

		transform.position = new Vector3 (50,50,-40);

	}

	void moveWithObject() {
		GameObject player = GameObject.FindGameObjectWithTag ("Player").gameObject;

		transform.position = new Vector3 (player.transform.position.x, 10, player.transform.position.z - 5);
	}

	void showNeutralControls() {
		GameManager.neutralPanel.gameObject.SetActive (true);
	}

	void TurnCamera() {
		
		//Debug.Log (Screen.width);

		int thirdOfScreen = Screen.width/3;
		//Debug.Log (thirdOfScreen);

		if (Input.mousePosition.x <= thirdOfScreen) {
			transform.Rotate(Vector3.down * Time.deltaTime * speed*2, Space.World);
		}

		if (Input.mousePosition.x >= (thirdOfScreen*2)) {
			transform.Rotate(Vector3.up * Time.deltaTime * speed*2, Space.World);
		}
	}

	void MoveContinuous() {

		Vector3 movement = Vector3.zero;
		Vector3 camEuler = transform.eulerAngles;
		camEuler.x = 0f;
		Quaternion normalizedRotation = Quaternion.Euler(camEuler);

		if (Input.GetKey(KeyCode.W))
		{
			movement += normalizedRotation * Vector3.forward;
		}

		if (Input.GetKey(KeyCode.S))
		{
			movement -= normalizedRotation * Vector3.forward;
		}

		if (Input.GetKey(KeyCode.A))
		{
			movement -= normalizedRotation * Vector3.right;
		}

		if (Input.GetKey(KeyCode.D))
		{
			movement += normalizedRotation * Vector3.right;
		}

		if (movement.magnitude > 1f)
		{
			movement = movement.normalized;
		}

		transform.position += movement * speed * Time.deltaTime;

	}

	void moveX(int direction) {

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		transform.position += move * speed * Time.deltaTime;

	}

	void moveZ(int direction) {

		Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical"));
		transform.position += move * speed * Time.deltaTime;

	}
		
}
