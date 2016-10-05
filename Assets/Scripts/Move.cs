// MoveTo.cs
using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	NavMeshAgent agent;
	int i;
	bool start;


	Transform[] goals;

	void Start () {

		//goals = Collect.collectGoals ();
		//goals = new Transform[3];
		start = true;

			
	}



	void Update() {

		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.COLLECT &&
			Collect.goalsGotten) {

			if (start) {

				agent = GetComponent<NavMeshAgent> ();
				//GameObject.FindGameObjectWithTag("Swarm").GetComponent<NavMeshAgent> ();

				agent.speed = 14;
				i = 0;
				goals = Collect.goals;
				agent.destination = goals [i].position;
				print ("(Start) Going to X-" + goals[i].position.x + " Z-" + goals[i].position.z);
				print ("(Next step) Going to X-" + goals[i+1].position.x + " Z-" + goals[i+1].position.z);
				start = false;

			} else {

				float dist = Vector3.Distance (transform.position, goals[i].position);
				//Transform currentTarget = goals [i];

				if (dist < 3) {

					if (i < goals.Length - 1) {
						i++;
						agent.destination = goals [i].position;
					} else {
						Collect.goalsGotten = false;
						Collect.goals = new Transform[3];
						start = true;
					}

					/*else {
				print ("Reset i");
				i = 0;
				agent.destination = goals [i].position;
			}*/

				}

			}





		}
		


			
	}

	bool checkIfSameCoords(Transform a, Transform b) {
		return (a.position.x == b.position.x) && (a.position.z == b.position.z);
	}
		
}