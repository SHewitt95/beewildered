using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	private GameStates currentState;
	private Controller.Controls controller = null;

	public enum GameStates {CAMERA, BUILD, COLLECT, DISTRIBUTE, DEFEND};

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		// Initializes the game controller (XBox, keyboard, Playstation, etc...)
		if (controller == null) {
			controller = new Controller.Controls ();
		}
			
	}

	// Use this for initialization
	void Start () {
		currentState = GameStates.CAMERA;
	}
	
	// Update is called once per frame
	void Update () {

		checkUserInput (Input.inputString);

		switch (GetCurrentState()) {
			case GameStates.CAMERA:
				break;

			case GameStates.BUILD:
				break;

			case GameStates.COLLECT:
				break;

			case GameStates.DISTRIBUTE:
				break;

			case GameStates.DEFEND:
				break;

			default:
				break;
		}

	}

	public GameStates GetCurrentState() {
		return currentState;
	}

	void checkUserInput(string input) {
		//Debug.Log (input);
		switch(input) {
			case "b":
			currentState = GameStates.BUILD;
				break;
			case "B":
			currentState = GameStates.BUILD;
				break;
			case "v":
			currentState = GameStates.COLLECT;
				break;
			case "V":
			currentState = GameStates.COLLECT;
				break;
			case "n":
			currentState = GameStates.DISTRIBUTE;
				break;
			case "N":
			currentState = GameStates.DISTRIBUTE;
				break;
			case "m":
			currentState = GameStates.DEFEND;
				break;
			case "M":
			currentState = GameStates.DEFEND;
				break;
		default:
			if (Input.GetKeyDown(KeyCode.Escape)) {
				currentState = GameStates.CAMERA;
			}
			break;
		}
	}
}
