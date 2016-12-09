using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour {

	public static int numOfDandelions = 0;
	public static int numOfSunflowers = 0;
	public static int numOfOrangeTrees = 0;
	public static int numOfAppleTrees = 0;

	public Text dand;
	public Text sunf;
	public Text orange;
	public Text apple;

	public Text dandBuild;
	public Text sunfBuild;
	public Text orangeBuild;
	public Text appleBuild;

	public Text dandCost;
	public Text sunfCost;
	public Text orangeCost;
	public Text appleCost;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		dand.text = "" + numOfDandelions;
		sunf.text = "" + numOfSunflowers;
		orange.text = "" + numOfOrangeTrees;
		apple.text = "" + numOfAppleTrees;

		dandBuild.text = "" + numOfDandelions;
		sunfBuild.text = "" + numOfSunflowers;
		orangeBuild.text = "" + numOfOrangeTrees;
		appleBuild.text = "" + numOfAppleTrees;

		dandCost.text = "" + Dandelion.getCost();
		sunfCost.text = "" + Sunflowers.getCost();
		orangeCost.text = "" + OrangeTree.getCost();
		appleCost.text = "" + AppleTree.getCost();
	
	}

	public static void incrementItem(string item) {

		switch (item) {

		case "Dandelion":
			numOfDandelions++;
			break;
		case "Sunflower":
			numOfSunflowers++;
			break;
		case "Orange Tree":
			numOfOrangeTrees++;
			break;
		case "Apple Tree":
			numOfAppleTrees++;
			break;
		default:
			break;

		}

	}

	public static void decrementItem(string item) {

		switch (item) {

		case "Dandelion":
			numOfDandelions--;
			break;
		case "Sunflower":
			numOfSunflowers--;
			break;
		case "Orange Tree":
			numOfOrangeTrees--;
			break;
		case "Apple Tree":
			numOfAppleTrees--;
			break;
		default:
			break;

		}

	}

}
