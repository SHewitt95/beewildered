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

	float totalSeconds = 1f;
	float maxIntensity = 5f;

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

		if (GameManager.instance.GetCurrentState () == GameManager.GameStates.COLLECT) {
			GetComponent<Light> ().enabled = true;

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
