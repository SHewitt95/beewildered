using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour
{
	int position;
	int lifespan;
	int pollenValue;
	int nectarValue;
	int cost;

	// Time elements
	int startTime;
	int endTime; // endTime = startTime + lifespan
	int currentTime;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public int getNectarValue() {
		return nectarValue;
	}

	public int getCost() {
		return cost;
	}

	public int getPollenValue() {
		return pollenValue;
	}
}

