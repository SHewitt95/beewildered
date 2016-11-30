using UnityEngine;
using System.Collections;

public class Dandelion : MonoBehaviour {

	int position;
	int lifespan;
	int pollenValue;
	static int nectarValue = 3;
	static int cost = 0;

	float totalSeconds = 1f;
	float maxIntensity = 5f;

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

		if (GameManager.instance.GetCurrentState () == GameManager.GameStates.COLLECT) {
			GetComponent<Light> ().enabled = true;
			GetComponent<Light> ().color = Color.white;

			if (collectingPollen) {
				GetComponent<Light> ().color = Color.red;
			} else {
				GetComponent<Light> ().color = Color.white;
			}

		} else {
			GetComponent<Light> ().enabled = false;
		}

		if (decay >= decayLimit / 2 &&
			GameManager.instance.GetCurrentState() == GameManager.GameStates.CAMERA) {
			GetComponent<Light> ().enabled = true;
			GetComponent<Light> ().color = Color.yellow;
			blinkLight ();
		}

	}

	IEnumerator blinkLight() {
		float waitTime = totalSeconds / 2;

		while(GetComponent<Light>().intensity < maxIntensity) {
			GetComponent<Light> ().intensity += Time.deltaTime / waitTime;
			yield return null;
		}

		while (GetComponent<Light>().intensity > 0) {
			GetComponent<Light> ().intensity -= Time.deltaTime / waitTime;
			yield return null;
		}

		yield return null;
	}

	void reduceLifespan() {
		decay++;

		if (decay == decayLimit) {
			//print (position);
			GameManager.grid [position] = 0;
			GameManager.gridValues [position] = 0;
			GameManager.allGameObjects [position] = null;
			GameManager.numOfPlants--;
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
