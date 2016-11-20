using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	int position;
	int lifespan;
	int pollenValue;
	static int nectarValue;
	static int cost = 15;
	int productionRate;

	public bool collectingPollen = false;
	float decay = 0f;
	float decayLimit = 6000;

	int currentTime;

	public GameObject player;

	// Use this for initialization
	void Start () {
		position = SnapMovement.staticCurrentPos;
		lifespan = 240;
		pollenValue = 3;
		nectarValue = 9;
		cost = 15;
		productionRate = 15;

		collectingPollen = false;

		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (!collectingPollen) {
			reduceLifespan ();
		} else {
			decay = 0;
		}
	
	}

	void reduceLifespan() {
		decay++;

		if (decay == decayLimit) {
			//print (position);
			GameManager.grid [position] = 0;
			GameManager.gridValues [position] = 0;
			GameManager.allGameObjects [position] = null;
			Destroy (this.gameObject);
		}

	}

	public void producePollen() {
		if (currentTime % productionRate == 0) {
			Bank.addPollen (pollenValue);
		}
	}

	public void reduceLifeSpan() {
		if (currentTime % productionRate == 0) {
			lifespan--;
		}

		if (lifespan == 0) {
			GameManager.grid [position] = 0;
			Destroy (this.gameObject);
		}
	}

	public static int getNectarValue() {
		return nectarValue;
	}

	public static int getCost() {
		return cost;
	}
}
