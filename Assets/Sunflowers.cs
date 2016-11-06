using UnityEngine;
using System.Collections;

public class Sunflowers : MonoBehaviour {

	int position;
	int lifespan;
	int pollenValue;
	static int nectarValue = 3;
	static int cost = 0;

	int frames;
	int minute;
	int rate;

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
		frames += 1;
		if ((frames%(minute*rate)) == 0) {
			Bank.addPollen (pollenValue);
			lifespan--;
		}

		if (lifespan==0) {
			GameManager.grid [position] = 0;
			frames = 0;
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
