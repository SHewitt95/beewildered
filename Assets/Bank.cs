﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bank : MonoBehaviour {

	public static int pollen;
	public static int nectar;
	public static int honey;

	public Text pollenText;
	public Text nectarText;
	public Text honeyText;

	// Use this for initialization
	void Start () {

		pollen = 0;
		nectar = 50;
		honey = 0;

		pollenText.text = "Pollen: ";
		nectarText.text = "Nectar: ";
		honeyText.text = "Honey: ";
			
	}
	
	// Update is called once per frame
	void Update () {

		pollenText.text = "Pollen: " + pollen;
		nectarText.text = "Nectar: " + nectar;
		honeyText.text = "Honey: " + honey;
	
	}

	public static bool subtractPollen(int amount) {

		int temp;

		temp = pollen;

		if ((temp -= amount) >= 0) {
			pollen = temp;
			return true;
		}

		return false;
	}

	public static bool subtractNectar(int amount) {

		int temp;

		temp = nectar;

		if ((temp -= amount) >= 0) {
			nectar = temp;
			return true;
		}

		return false;

	}

	public static void addPollen(int amount) {
		pollen += amount;
	}

	public static void addNectar(int amount) {
		nectar += amount;
	}
}
