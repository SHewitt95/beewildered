// MoveTo.cs
using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	NavMeshAgent agent;
	int i;
	bool start;

	GameObject hive;


	Transform[] goals;

	void Start () {

		hive = GameObject.FindGameObjectWithTag ("Hive");

		agent = GetComponent<NavMeshAgent> ();

		agent.speed = 10;
		i = 0;
		goals = Collect.goals;
		agent.destination = goals [i].position;

			
	}



	void Update() {


		float dist = Vector3.Distance (transform.position, goals[i].position);
		//Transform currentTarget = goals [i];

		if (dist < 3) {

			if (i < goals.Length - 1) {
				
				i++;
				agent.destination = goals [i].position;

			} else {
				Collect.goalsGotten = false;
				Collect.goals = new Transform[3];
				agent.destination = hive.transform.position;

			}

		}

		if (Vector3.Distance(agent.transform.position, hive.transform.position) < 3 &&
			Collect.goalsGotten == false) {

			Bank.addNectar (sumArrayValues(Collect.patchValues));

			Destroy (this.gameObject);
		
		}
			
	}

	int sumArrayValues(int[] array) {
		int sum = 0;

		for (int i = 0; i < array.Length; i++) {
			sum += array [i];
		}

		return sum;
	}

	bool checkIfSameCoords(Transform a, Transform b) {
		return (a.position.x == b.position.x) && (a.position.z == b.position.z);
	}
		
}