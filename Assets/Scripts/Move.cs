// MoveTo.cs
using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	NavMeshAgent agent;
	int i;
	bool active;

	GameObject hive;

	Transform[] goals;

	public Color c1 = Color.yellow;
	int lineLength = 5;

	void Start () {

		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer> ();
		lineRenderer.material = new Material (Shader.Find("Particles/Additive"));
		lineRenderer.SetColors (c1,c1);
		lineRenderer.SetWidth (0.2f, 0.2f);
		lineRenderer.SetVertexCount (lineLength);

		hive = GameObject.FindGameObjectWithTag ("Hive");

		agent = GetComponent<NavMeshAgent> ();

		agent.speed = 10;
		i = 0;
		goals = Collect.returnGoals();
		agent.destination = goals [i].position;
		lineRenderer.SetPositions (getVector3s(goals));

		active = true;

	}

	public Vector3[] getVector3s(Transform[] goals) {

		Vector3[] points = new Vector3[5];

		points [0] = hive.transform.position;
		points [4] = hive.transform.position;

		points[1] = goals[0].position;
		points[2] = goals[1].position;
		points[3] = goals[2].position;

		return points;

	}



	void Update() {


		float dist = Vector3.Distance (transform.position, goals[i].position);
		//Transform currentTarget = goals [i];

		/*
		LineRenderer lineRenderer = GetComponent<LineRenderer> ();
		float t = Time.time;
		int j = 0;*/

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
			active = false;

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