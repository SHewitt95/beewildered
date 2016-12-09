using UnityEngine;
using System.Collections;

public class Hive : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void purchaseItem(string item) {

		switch (item) {

		case "Dandelion":
			if (Bank.subtractHoney(Dandelion.getCost())) {
				Inventory.incrementItem (item);
			}
			break;
		case "Sunflower":
			if (Bank.subtractHoney(Sunflowers.getCost())) {
				Inventory.incrementItem (item);
			}
			break;
		case "Orange Tree":
			if (Bank.subtractHoney(OrangeTree.getCost())) {
				Inventory.incrementItem (item);
			}
			break;
		case "Apple Tree":
			if (Bank.subtractHoney(AppleTree.getCost())) {
				Inventory.incrementItem (item);
			}
			break;
		default:
			break;

		}

	}


}
