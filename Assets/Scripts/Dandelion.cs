using UnityEngine;
using System.Collections;

public class Dandelion : MonoBehaviour {

	int position;
	int lifespan;
	int pollenValue;
	static int nectarValue = 3;
	static int cost = 0;

	int frames;
	int minute;
	int rate;

	public bool collectingPollen = false;
	float decay = 0f;
	float decayLimit = 1500;

	public static GameObject player;

	// Use this for initialization
	void Start () {
		position = SnapMovement.staticCurrentPos;
		lifespan = 6;
		pollenValue = 1;

		player = GameObject.FindGameObjectWithTag ("Player");

		frames = 0;
		minute = 60;
		rate = 10;
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

	public static int getNectarValue() {
		return nectarValue;
	}

	public static int getCost() {
		return cost;
	}
}
