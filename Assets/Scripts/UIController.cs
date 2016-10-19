using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public GameObject openingMenu;

	// Use this for initialization
	void Start () {

		//openingMenu = GameObject.FindGameObjectWithTag ("Opening Menu");

	
	}
	
	// Update is called once per frame
	void Update () {
		//print(GameManager.instance.GetCurrentState());
	}

	public void StartButton() {
		openingMenu.gameObject.SetActive (false);
		GameManager.instance.checkUserInput ("x");
	}
}
