using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

	public static Transform[] goals;
	int spotsSelected;
	GameObject player;

	public GameObject empty;

	public static bool goalsGotten;

	// Use this for initialization
	void Start () {

		goals = new Transform[3];
		spotsSelected = 0;
		goalsGotten = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		//collectGoals ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.COLLECT &&
				spotsSelected < goals.Length) {

			Debug.Log ("Collect!");

			if (Input.GetKeyDown(KeyCode.Return)) {
				//Transform temp = player.transform;

				GameObject hi = (GameObject) Instantiate(empty, player.transform.position, player.transform.rotation);

				goals [spotsSelected] = hi.transform;
				print ("Coordinates: X-" + hi.transform.position.x + " Z-" + hi.transform.position.z);
				//printGoals ();

				spotsSelected++;
			}

			if (spotsSelected == goals.Length) {
				print ("Got goals!");
				goalsGotten = true;
				printGoals ();
			}

		}




	
	}

	void printGoals() {
		for (int i = 0; i < goals.Length; i++) {
			print ("Goal " + i + ": X-" + goals[i].position.x + " Z-" + goals[i].position.z);
		}
	}

	public static void InitiateCollectState() {
		//print("Goals length: " + Move.getGoals ().Length);
		//Move.startJourney();
	}


	public static Transform[] collectGoals() {
		/*
		spotsSelected = 0;

		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		if (Input.GetKeyDown(KeyCode.Return)) {
			goals [spotsSelected] = player.transform;
			spotsSelected++;
		}
			
		print ("Got goals!");
		*/
		return goals;


	}

	public static Transform[] returnGoals() {
		return goals;
	}


}
