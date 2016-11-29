using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwarmKeeper : MonoBehaviour {

	public Swarm swarm;

	Swarm[] allSwarms;
	int numberOfSwarms;
	Swarm selectedSwarm;
	int numOfSelectedSwarm;
	public enum SwarmStates {BUILD, COLLECT, NURSE, IDLE, COOLDOWN};

	GameObject hive;

	public UIController uicontroller;

	static Color c1 = Color.yellow;
	static Color c2 = Color.red;
	static Color c3 = Color.blue;
	static Color c4 = Color.white;

	Color[] allColors = {c1, c2, c3, c4};

		

	// Use this for initialization
	void Start () {

		//allSwarms = new Swarm[4];
		//numberOfSwarms = 0;

		allSwarms = new Swarm[4];
		numberOfSwarms = 4;
		hive = GameObject.FindGameObjectWithTag ("Hive");
			
	}
	
	// Update is called once per frame
	void Update () {
		//print (Time.time);

	}

	public void drawSwarmPath() {
		List<GameObject> paths = selectedSwarm.getPathLocations ();
		//print (paths.Count);

		if (paths.Count > 0) {

			int lengthOfLineRenderer = paths.Count + 1;
			int i = 0;

			//LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

			LineRenderer lineRenderer = GetComponent<LineRenderer>();
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
			lineRenderer.SetColors(allColors[numOfSelectedSwarm], allColors[numOfSelectedSwarm]);
			lineRenderer.SetWidth(1F, 1F);
			lineRenderer.SetVertexCount(lengthOfLineRenderer);


			lineRenderer.SetPositions (makeVector3Array(paths));

		}


	}

	Vector3[] makeVector3Array(List<GameObject> list) {
		//Vector3 array = new Vector3[99];

		List<Vector3> array = new List<Vector3> ();
		int i = 1;

		array.Add(GameObject.FindGameObjectWithTag ("Hive").transform.position);

		foreach (GameObject obj in list) {
			array.
				Add (obj.transform.position);
		}

		return array.ToArray();
	}

	public void spawnAllSwarms() {
		Vector3 pos = GameObject.FindGameObjectWithTag ("Hive").transform.position;

		allSwarms[0] = (Swarm) Instantiate (swarm, pos, GameObject.FindGameObjectWithTag("Hive").transform.rotation);
		allSwarms[1] = (Swarm) Instantiate (swarm, pos, GameObject.FindGameObjectWithTag("Hive").transform.rotation);
		allSwarms[2] = (Swarm) Instantiate (swarm, pos, GameObject.FindGameObjectWithTag("Hive").transform.rotation);
		allSwarms[3] = (Swarm) Instantiate (swarm, pos, GameObject.FindGameObjectWithTag("Hive").transform.rotation);
	}

	// Used when rerouting a Swarm
	public void killSwitch() {
		selectedSwarm.clearPathLocations ();
		selectedSwarm.i = 0;
		selectedSwarm.changeState (SwarmKeeper.SwarmStates.IDLE);
		selectedSwarm.agent.destination = GameObject.FindGameObjectWithTag ("Hive").transform.position;
	}

	// Used when placing a Swarm on cooldown.
	public void minorKillSwitch(Swarm thisSwarm) {
		thisSwarm.i = 0;
		thisSwarm.changeState (SwarmKeeper.SwarmStates.COOLDOWN);
		thisSwarm.agent.destination = GameObject.FindGameObjectWithTag ("Hive").transform.position;

		StartCoroutine (resumeCollection(thisSwarm));

	}

	public IEnumerator resumeCollection(Swarm thisSwarm) {
		yield return new WaitForSeconds (Vector3.Distance(thisSwarm.transform.position, GameObject.FindGameObjectWithTag ("Hive").transform.position));
		thisSwarm.changeState (SwarmKeeper.SwarmStates.COLLECT);
	}

	public void setSelectedSwarm(int num) {
		selectedSwarm = allSwarms[num];
		numOfSelectedSwarm = num;
	}

	public void upgradeSwarm() {

		if (Bank.subtractHoney (100)) {
			selectedSwarm.upgrade ();
			uicontroller.showUpgradeNotice ();
		} else {
			uicontroller.showUpgradeFail ();
		}

	}

	public Swarm getSelectedSwarm() {
		return selectedSwarm;
	}
		

	public Swarm[] getSwarms() {
		return allSwarms;
	}

	public void addSwarm() {
		if (numberOfSwarms < allSwarms.Length) {
			
			float num = Random.Range (40, 60);

			Vector3 pos = new Vector3 (num, 1, num);
			Swarm newSwarm = (Swarm) Instantiate (swarm, pos, GameObject.FindGameObjectWithTag("Player").transform.rotation);
			allSwarms[numberOfSwarms] = newSwarm;
			numberOfSwarms++;

		}
	}

	public int getNumberOfSwarms() {
		return numberOfSwarms;
	}

	/*
	public void testLocations() {
		//float num = Random.Range (30, 90);

		foreach (Swarm swarm in allSwarms) {

			Vector3 pos1 = new Vector3 (Random.Range (30, 90),1,Random.Range (30, 90));
			Vector3 pos2 = new Vector3 (Random.Range (30, 90),1,Random.Range (30, 90));
			Vector3 pos3 = new Vector3 (Random.Range (30, 90),1,Random.Range (30, 90));

			swarm.addPathLocation (pos1);
			swarm.addPathLocation (pos2);
			swarm.addPathLocation (pos3);

		}
			
	}
	*/
}
